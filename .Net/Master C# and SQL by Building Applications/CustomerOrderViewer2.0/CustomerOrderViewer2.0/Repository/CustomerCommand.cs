using CustomerOrderViewer2._0.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer2._0.Repository
{
    internal class CustomerCommand
    {
        private string _connectionString;

        public CustomerCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Upsert(int customerId, string firstName, string middleName, string lastName, int age, string userId)
        {
            var upsertStatment = "Customer_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CustomerId", typeof(int));
            dataTable.Columns.Add("FristName", typeof(string));
            dataTable.Columns.Add("MiddleName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Rows.Add(customerId, firstName, middleName, lastName, age);

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(upsertStatment, new { @CustomerType = dataTable.AsTableValuedParameter("CustomerType"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int customerId, string userId)
        {
            var upsertStatement = "Customer_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(upsertStatement, new { @CustomerId = customerId, @UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IList<CustomerModel> GetList()
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();

            var sqlStatment = "Customer_GetList";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                customerModels = sqlConnection.Query<CustomerModel>(sqlStatment).ToList();
            }

            return customerModels;
        }
    }
}
