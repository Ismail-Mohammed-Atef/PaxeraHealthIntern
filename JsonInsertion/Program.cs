using Microsoft.EntityFrameworkCore;
using System;
using Vitals.Repository.Data;

namespace JsonInsertion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VitalsDbContext context = new VitalsDbContext();
            var x = new DatabaseMaker(context);
            x.InsertJson("242e388d-0430-4145-acdf-f5fac5812cc9", "C:\\Json\\MedicalDocs.json");
        }
    }
}
