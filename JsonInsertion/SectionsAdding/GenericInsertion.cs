using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitals.Core.Entities;
using Vitals.Repository.Data;

namespace JsonInsertion.SectionsAdding
{
    public class GenericInsertion
    {
        private readonly VitalsDbContext _context;

        public GenericInsertion(VitalsDbContext context)
        {
            _context = context;
        }
        public Entry InsertInMaster(string userId, Sections Type,JObject data , JToken item)
        {
            //string json = File.ReadAllText("C:\\Json\\MedicalDocs.json");
            //var data = JObject.Parse(json);
            Entry entry = new Entry();
            //string v = data["Vitals"].First()["name"].ToString();
            //foreach (var item in data[kind])
            //{
                entry.UId = item["uid"].ToString();
                entry.SectionName = item["name"]?.ToString() ?? string.Empty;
                entry.SectionType = Type;
                entry.Userid = userId;
                entry.Description = item["des"]?.ToString()??string.Empty;
                entry.Organization = item["Org"]?.ToString()??string.Empty;
                entry.Type = item["type"]?.ToString()??string.Empty;
                entry.PathOfFile = item["path"]?.ToString()??string.Empty;
                entry.UploadedDate = (DateTime?)item["UploadedDate"];
                entry.source = item["Src"]?.ToString() ?? string.Empty;
                _context.Entry.Add(entry);
            //}

            //_context.SaveChanges();
            return entry;
        }

        public void InsertInDocuments(Entry entry,JObject data,JToken item)
        {
            //string json = File.ReadAllText("C:\\Json\\MedicalDocs.json");
            //var data = JObject.Parse(json);
            //string v = data["Vitals"].First()["name"].ToString();
            MedicalDocuments medicalDocuments = new MedicalDocuments();
            //foreach (var item in data[kind])
            //{
                medicalDocuments.EntryId = entry.UId;
                medicalDocuments.filePath = item["path"]?.ToString();
                medicalDocuments.FileType = item["type"]?.ToString();
                medicalDocuments.Ofn = item["ofn"]?.ToString()??string.Empty;
                _context.MedicalDocuments.Add(medicalDocuments);
            //}
        }

    }
}
