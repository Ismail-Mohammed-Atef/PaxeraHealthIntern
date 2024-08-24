using System.Text.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vitals.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Vitals.Repository.Data;
using JsonInsertion.SectionsAdding;

namespace JsonInsertion
{
    public class DatabaseMaker
    {
        private VitalsDbContext _context;

        public DatabaseMaker(VitalsDbContext context)
        {
            _context = context;
        }
        public void InsertJson(string userId , string filePath)
        {
            if (_context.Entry.Count() == 0)
            {
                string json = File.ReadAllText(filePath);
                var data = JObject.Parse(json);

                GenericInsertion insert = new GenericInsertion(_context);
                foreach (var item in data["Vitals"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Vitals, data, item);
                    if (entry.Type == "CCD")
                    {
                        foreach (var readings in item["Readings"])
                        {
                            var reading = new VitalReadings()
                            {
                                UId = readings["uid"].ToString(),
                                EntryId = entry.UId,
                                TypeOfVital = (Types)Enum.Parse(typeof(Types), readings["TypeString"].ToString().Replace(" ", "_"), true),
                                Value = readings["Value"].ToString(),
                                Units = readings["Units"].ToString(),
                                Comment = readings["Comment"].ToString(),
                                NotedDate = (DateTime)readings["NotedDate"]
                            };
                            _context.VitalReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Labs"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Lab, data, item);
                    if (entry.Type == "CCD")
                    {
                        LabReadings reading = new LabReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Name = readings["Name"].ToString();
                            reading.LabTitle = readings["Title"]?.ToString() ?? string.Empty;
                            reading.LabCode = readings["Code"]?.ToString() ?? string.Empty;
                            reading.Value = readings["Value"]?.ToString() ?? string.Empty;
                            reading.Units = readings["Units"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            reading.NotedDate = (DateTime)readings["NotedDate"];
                            _context.LabReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Meds"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Meds, data, item);
                    if (entry.Type == "CCD")
                    {
                        Medications_Readings reading = new Medications_Readings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Name = readings["Name"]?.ToString();
                            reading.Directions = readings["Direcs"]?.ToString() ?? string.Empty;
                            reading.StartDate = readings["SDate"]?.ToString() ?? string.Empty;
                            reading.EndDate = readings["EDate"]?.ToString() ?? string.Empty;
                            reading.Status = readings["Status"]?.ToString() ?? string.Empty;
                            reading.Quantity = readings["Quantity"]?.ToString() ?? string.Empty;
                            reading.MedCode = readings["Code"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.Medications_Readings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Prescripts"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Prescripts, data, item);
                    if (entry.Type == "CCD")
                    {
                        PrescriptsReadings reading = new PrescriptsReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Name = readings["Name"]?.ToString();
                            reading.Status = readings["Status"]?.ToString() ?? string.Empty;
                            reading.PresCode = readings["Code"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.PrescriptsReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Allergies"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Allergies, data, item);
                    if (entry.Type == "CCD")
                    {
                        AllergiesReadings reading = new AllergiesReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Type = readings["Type"]?.ToString() ?? string.Empty;
                            reading.SubType = readings["Sub"]?.ToString() ?? string.Empty;
                            reading.Stat = readings["Stat"]?.ToString() ?? string.Empty;
                            reading.Reaction = readings["Reac"]?.ToString() ?? string.Empty;
                            reading.Severity = readings["Sev"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.AllergiesReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["History"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.History, data, item);
                    if (entry.Type == "CCD")
                    {
                        HistoryReadings reading = new HistoryReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Diagnosis = readings["Diagonsis"]?.ToString() ?? string.Empty;
                            reading.Relation = readings["Relation"]?.ToString() ?? string.Empty;
                            reading.Age = readings["Age"]?.ToString() ?? string.Empty;
                            reading.Status = readings["Status"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.HistoryReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Family"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Family, data, item);
                    if (entry.Type == "CCD")
                    {
                        HistoryReadings reading = new HistoryReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Diagnosis = readings["Diagonsis"]?.ToString() ?? string.Empty;
                            reading.Relation = readings["Relation"]?.ToString() ?? string.Empty;
                            reading.Age = readings["Age"]?.ToString() ?? string.Empty;
                            reading.Status = readings["Status"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.HistoryReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Social"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Social, data, item);
                    if (entry.Type == "CCD")
                    {
                        HistoryReadings reading = new HistoryReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Diagnosis = readings["Diagonsis"]?.ToString() ?? string.Empty;
                            reading.Relation = readings["Relation"]?.ToString() ?? string.Empty;
                            reading.Age = readings["Age"]?.ToString() ?? string.Empty;
                            reading.Status = readings["Status"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.HistoryReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Problems"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Problems, data, item);
                    if (entry.Type == "CCD")
                    {
                        ProblemsReadings reading = new ProblemsReadings();
                        foreach (var readings in item["Readings"])
                        {

                            reading.UId = readings["uid"].ToString();
                            reading.EntryId = entry.UId;
                            reading.Name = readings["Name"]?.ToString() ?? string.Empty;
                            reading.Status = readings["Status"]?.ToString() ?? string.Empty;
                            reading.ProCode = readings["Code"]?.ToString() ?? string.Empty;
                            reading.ICD10 = readings["ICD10"]?.ToString() ?? string.Empty;
                            reading.NotedDate = readings["NotedDate"]?.ToString() ?? string.Empty;
                            reading.Comment = readings["Comment"]?.ToString() ?? string.Empty;
                            _context.ProblemsReadings.Add(reading);
                        }
                    }
                    else
                    {
                        insert.InsertInDocuments(entry, data, item);
                    }
                }
                foreach (var item in data["Reports"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Reports, data, item);
                    insert.InsertInDocuments(entry, data, item);
                }
                foreach (var item in data["Others"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Others, data, item);
                    insert.InsertInDocuments(entry, data, item);
                }
                foreach (var item in data["Dental"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Dental, data, item);
                    insert.InsertInDocuments(entry, data, item);
                }
                foreach (var item in data["Opthal"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.Opthal, data, item);
                    insert.InsertInDocuments(entry, data, item);
                }
                foreach (var item in data["ECG"])
                {
                    var entry = insert.InsertInMaster(userId, Sections.ECG, data, item);
                    insert.InsertInDocuments(entry, data, item);
                }
            }
            _context.SaveChanges();
        }
    }
}

//string v = data["Vitals"].First()["name"].ToString();
//foreach (var item in data["Vitals"])
//{
//    var entry = new Entry()
//    {
//        UId = item["uid"].ToString(),
//        SectionName = item["name"].ToString(),
//        SectionType = Sections.Vitals,
//        Userid = userId,
//        Description = item["des"].ToString(),
//        Organization = item["Org"].ToString(),
//        Type = item["type"].ToString(),
//        PathOfFile = item["path"].ToString(),
//        UploadedDate = (DateTime)item["UploadedDate"],
//        source = item["Src"]?.ToString() ?? string.Empty,

//    };
//    if (entry.Type == "CCD")
//    {
//        foreach (var readings in item["Readings"])
//        {
//            entry.NotedDate = (DateTime)readings["NotedDate"];
//            entry.Comment = readings["Comment"].ToString();
//            var reading = new VitalReadings()
//            {
//                UId = readings["uid"].ToString(),
//                EntryId = entry.UId,
//                TypeOfVital = (Types)Enum.Parse(typeof(Types), readings["TypeString"].ToString().Replace(" ","_"), true),
//                Value = readings["Value"].ToString(),
//                Units = readings["Units"].ToString()
//            };
//            _context.VitalReadings.Add(reading);
//        }
//    }
//    else
//    {
//        var documents = new MedicalDocuments()
//        {
//            EntryId = entry.UId,
//            filePath = item["path"].ToString(),
//            FileType = item["type"].ToString(),
//            Ofn = item["ofn"].ToString()
//        };
//        _context.MedicalDocuments.Add(documents);
//    }
//    _context.Entry.Add(entry);
//    _context.SaveChanges();
//}
