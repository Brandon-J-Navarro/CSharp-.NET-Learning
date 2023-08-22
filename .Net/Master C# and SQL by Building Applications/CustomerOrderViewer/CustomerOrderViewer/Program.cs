using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using System.Data.SqlClient;

namespace CustomerOrderViewer
{
    class Progam
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=localhost;Initial Catalog=CustomerOrderViewer;Persist Security Info=True;User ID=sa;Password=***************");

                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach (CustomerOrderDetailModel customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine("{0}: FullName: {1} {2} (Id: {3}) - Purchased {4} for {5} (Id: {6})",
                            customerOrderDetailModel.CustomerOrderId,
                            customerOrderDetailModel.FirstName,
                            customerOrderDetailModel.LastName,
                            customerOrderDetailModel.CustomerId,
                            customerOrderDetailModel.Description,
                            customerOrderDetailModel.Price,
                            customerOrderDetailModel.ItemId
                            );
                    }
                    Console.WriteLine("Total order count: {0}", customerOrderDetailModels.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong {0}", ex.Message);
            }

        }
    }
}