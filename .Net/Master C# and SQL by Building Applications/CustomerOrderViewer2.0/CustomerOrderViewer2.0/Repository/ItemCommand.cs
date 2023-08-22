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
    internal class ItemCommand
    {
        private string _connectionString;

        public ItemCommand(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Upsert(int itemId, string Description, decimal price, string userId)
        {
            var upsertStatment = "Item_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("ItemId", typeof(int));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Rows.Add(itemId, Description, price);

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(upsertStatment, new { @ItemType = dataTable.AsTableValuedParameter("ItemType"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int itemId, string userId)
        {
            var upsertStatement = "Item_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(upsertStatement, new { @ItemId = itemId, @UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IList<ItemModel> GetList()
        {
            List<ItemModel> itemModels = new List<ItemModel>();

            var sqlStatment = "Item_GetList";

            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                itemModels = sqlConnection.Query<ItemModel>(sqlStatment).ToList();
            }

            return itemModels;
        }
    }
}
