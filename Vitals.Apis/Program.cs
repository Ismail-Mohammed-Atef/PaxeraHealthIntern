using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vitals.Apis.DTO;
using Vitals.Core.Entities;
using Vitals.Repository.Data;
using Vitals.Repository.Identity;

namespace Vitals.Apis
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false));
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; 
            });
            //builder.Services.AddDbContext<VitalsDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            builder.Services.AddScoped<VitalsDbContext>();
            builder.Services.AddScoped<SignInManager<IdentityUser>>();
            builder.Services.AddScoped<UserManager<IdentityUser>>();

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var app = builder.Build();

            app.MapGet("/", () => "hello world");

            app.MapPost("/Register", async (RegisterDto model,UserManager<IdentityUser> userManager) =>
            {
                var emailUser = await userManager.FindByEmailAsync(model.Email);
                if(emailUser is not null)
                    return Results.BadRequest(error:"Email Duplicated");

                var user = new IdentityUser()
                {
                    UserName = model.Name,
                    Email = model.Email,

                };
                var operation = await userManager.CreateAsync(user,model.Password);

                if (!operation.Succeeded)
                    return Results.BadRequest(error:"Failed To Create User");

                return Results.Ok();
            });
            app.MapPost("/login", async (LoginDto model, UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager) =>
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is null)
                    return Results.BadRequest(error:"There Is No User With This Email");

                var result = await signInManager.CheckPasswordSignInAsync(user,model.password, false);

                if (!result.Succeeded)
                    return Results.Unauthorized();

                
                return Results.Ok(user.Id);
            });

            app.MapGet("/GetAllVitals/{id}", async (string id , VitalsDbContext dbContext) =>
            {
                var vitals = await dbContext.Entry.Where(v => v.Userid == id).Include(e=>e.MedicalDocuments).Include(e=>e.Medications_Readings).Include(e=>e.ProblemsReadings).Include(e=>e.HistoryReadings).Include(e=>e.AllergiesReadings).Include(e=>e.VitalReadings).Include(e=>e.LabReadings).Include(e=>e.PrescriptsReadings).ToListAsync();

                if(vitals is null)
                    return Results.BadRequest();

                return Results.Ok(vitals);
            });

            app.MapPost("/AddVital", (PatientVitalsDto model, VitalsDbContext dbContext) =>
            {

                bool isDefined = Enum.IsDefined(typeof(Types), model.VitalTypes);
                if (isDefined == false)
                    return Results.BadRequest(error:"There Is No Vital With That Name");

                PatientVitals vital = new PatientVitals()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    VitalTypes = (Types)Enum.Parse(typeof(Types), model.VitalTypes, true),
                    VitalValues = model.VitalValues,
                    VitalDate = model.VitalDate

                };
                if(vital == null)
                    return Results.BadRequest(error:"No Vital Added");


                var count = dbContext.PatientVitals.Add(vital);
                dbContext.SaveChanges();


                return Results.Ok();
            });

            app.MapDelete("/RemoveVital/{id}", (int id, VitalsDbContext dbContext) =>
            {
                var vital = dbContext.PatientVitals.FirstOrDefault(v => v.Id == id);

                if(vital == null)
                    return Results.BadRequest();

                dbContext.PatientVitals.Remove(vital);
                dbContext.SaveChanges();

                return Results.Ok();
            });


            app.Run();
        }
    }
}
