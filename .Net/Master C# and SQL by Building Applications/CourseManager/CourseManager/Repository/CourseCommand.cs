using CourseManager.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace CourseManager.Repository
{
    internal class CourseCommand
    {
        private string _connectionString;

        public CourseCommand(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IList<CourseModel> GetList()
        {
            List<CourseModel> courses = new List<CourseModel>();

            var sqlStatement = "Course_GetList";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                courses = connection.Query<CourseModel>(sqlStatement).ToList();
            }
            
            return courses;

        }

    }
}
