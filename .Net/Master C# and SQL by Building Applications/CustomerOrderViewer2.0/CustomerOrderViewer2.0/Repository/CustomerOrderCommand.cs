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
    internal class CustomerOrderCommand
    {
        private string _connectionString;

        public CustomerOrderCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Upsert(int customerOrderId, int customerId, int itemId, string userId)
        {
            var upsertStatment = "CustomerOrderDetail_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CustomerOrderId", typeof(int));
            dataTable.Columns.Add("CustomerId", typeof(int));
            dataTable.Columns.Add("ItemId", typeof(int));
            dataTable.Rows.Add(customerOrderId, customerId, itemId);

            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(upsertStatment, new { @CustomerOrderType = dataTable.AsTableValuedParameter("CustomerOrderType"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int customerOrderId,string userId)
        {
            var upsertStatement = "CustomerOrderDetail_Delete";

            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(upsertStatement, new { @CustomerOrderId = customerOrderId, @UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetail = new List<CustomerOrderDetailModel>();

            var sqlStatment = "CustomerOrderDetail_GetList";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                customerOrderDetail = sqlConnection.Query<CustomerOrderDetailModel>(sqlStatment).ToList();
            }

            return customerOrderDetail;
        }
    }
}
