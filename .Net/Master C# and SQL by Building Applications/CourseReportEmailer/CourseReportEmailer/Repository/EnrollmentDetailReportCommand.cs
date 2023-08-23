using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseReportEmailer.Models;
using Dapper;

namespace CourseReportEmailer.Repository
{
    internal class EnrollmentDetailReportCommand
    {
        private string _connectionString;
        public EnrollmentDetailReportCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<EnrollmentDetailReportModel> GetList()
        {
            List<EnrollmentDetailReportModel> enrollmentDetailReport = new List<EnrollmentDetailReportModel>();

            var sqlStatment = "EnrollmentReport_GetList";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                enrollmentDetailReport = connection.Query<EnrollmentDetailReportModel>(sqlStatment).ToList();
            }

            return enrollmentDetailReport;
        }
    }
}
