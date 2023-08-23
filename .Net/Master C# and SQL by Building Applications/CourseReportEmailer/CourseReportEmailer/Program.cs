using CourseReportEmailer.Repository;
using CourseReportEmailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Data;
using CourseReportEmailer.Workers;

namespace CourseReportEmailer
{
    class Program
    {
        private static readonly IConfiguration _configuration = Startup.BuildConfiguation();
        private static string _connectionString = _configuration["ConnectionString:sqlConnectionString"];
        private static readonly EnrollmentDetailReportCommand _Command = new EnrollmentDetailReportCommand(_connectionString);


        static void Main(string[] args)
        {
            try
            {
                
                IList<EnrollmentDetailReportModel> models = _Command.GetList();

                var reportFilesName = "Enrolment Detail Report.xlsx";

                EnrollmentDetailReportSpreadSheetCreator enrollmentSheetCreator = new EnrollmentDetailReportSpreadSheetCreator();
                enrollmentSheetCreator.Create(reportFilesName, models);

                EnrollmentDetailReportEmailSender emailer = new EnrollmentDetailReportEmailSender();
                emailer.Send(reportFilesName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: {0}", ex.Message);
            }
        }
    }
}