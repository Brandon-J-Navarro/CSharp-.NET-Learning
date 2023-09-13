using CourseManager.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repository
{
    internal class EnrollmentCommand
    {
        private string _connectionString;

        public EnrollmentCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<EnrollmentModel> GetList()
        {
            List<EnrollmentModel> enrollments = new List<EnrollmentModel>();

            var sqlStatement = "Enrollments_GetList";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                enrollments = connection.Query<EnrollmentModel>(sqlStatement).ToList();
            }

            foreach(var enrollment in enrollments)
            {
                enrollment.IsCommitted = true;
            }

            return enrollments;
        }

        public void Upsert(EnrollmentModel enrollmentModel)
        {
            var sqlStatement = "Enrollment_Upsert";
            var userId = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

            var datatable = new DataTable();
            datatable.Columns.Add("EnrollmentId", typeof(int));
            datatable.Columns.Add("StudentId", typeof(int));
            datatable.Columns.Add("CourseId", typeof(int));
            datatable.Rows.Add(enrollmentModel.EnrollmentId, enrollmentModel.StudentId, enrollmentModel.CourseId);

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlStatement, new { @EnrollmentType = datatable.AsTableValuedParameter("Enrollment_Type"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
