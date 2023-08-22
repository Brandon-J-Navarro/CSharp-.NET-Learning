using CustomerOrderViewer2._0.Repository;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CustomerOrderViewer2._0.Models
{
    class Progam
    {
        private static string _connectionString = @"Data Source=localhost;Initial Catalog=CustomerOrderViewer;Persist Security Info=True;User ID=sa;Password=Bnav74787!";
        private static readonly CustomerOrderCommand _customerOrderCommand = new CustomerOrderCommand(_connectionString);
        private static readonly CustomerCommand _customerCommand = new CustomerCommand(_connectionString);
        private static readonly ItemCommand _itemCommand = new ItemCommand(_connectionString);

        static void Main(string[] args)
        {
            try
            {
                var userId = string.Empty;
                var continueManaging = true;

                Console.WriteLine("What is your username?");
                userId = Console.ReadLine();

                do
                {
                    Console.WriteLine("1 - Retrieve | 2 - Update | 3 - Delete | 4 - Exit");

                    int mainOption = Convert.ToInt32(Console.ReadLine());

                    if (mainOption == 1)
                    {
                        var continueWithRetrieve = true;
                        do
                        {
                            Console.WriteLine("1 - Retrieve All | 2 - Retrieve Orders | 3 - Retrieve Customers | 4 - Retrieve Items | 5 - Exit");
                            int retrieveOption = Convert.ToInt32(Console.ReadLine());
                            if (retrieveOption == 1)
                            {
                                ShowAll();
                            }
                            else if (retrieveOption == 2)
                            {
                                ShowOrders();
                            }
                            else if (retrieveOption == 3)
                            {
                                ShowCustomers();
                            }
                            else if (retrieveOption == 4)
                            {
                                ShowItems();
                            }
                            else if (retrieveOption == 5)
                            {
                                continueWithRetrieve = false;
                            }
                            else
                            {
                                Console.WriteLine("Option not found");
                            }
                        } while (continueWithRetrieve == true);
                    }
                    else if (mainOption == 2)
                    {
                        var continueWithUpdate = true;
                        do
                        {
                            Console.WriteLine("1 - Update Order | 2 - Update Customer | 3 - Update Item | 4 - Exit");
                            int updateOption = Convert.ToInt32(Console.ReadLine());
                            if (updateOption == 1)
                            {
                                UpsertCustomerOrder(userId);
                            }
                            else if (updateOption == 2)
                            {
                                UpsertCustomer(userId);
                            }
                            else if (updateOption == 3)
                            {
                                UpsertItem(userId);
                            }
                            else if (updateOption == 4)
                            {
                                continueWithUpdate = false;
                            }
                            else
                            {
                                Console.WriteLine("Option not found");
                            }
                        } while (continueWithUpdate == true);
                    }
                    else if (mainOption == 3)
                    {
                        var continueWithDelete = true;
                        do
                        {
                            Console.WriteLine("1 - Delete Order | 2 - Delete Customer | 3 - Delete Item | 4 - Exit");
                            int deleteOption = Convert.ToInt32(Console.ReadLine());
                            if (deleteOption == 1)
                            {
                                DeleteCustomerOrder(userId);
                            }
                            else if (deleteOption == 2)
                            {
                                DeleteCustomer(userId);
                            }
                            else if (deleteOption == 3)
                            {
                                DeleteItem(userId);
                            }
                            else if (deleteOption == 4)
                            {
                                continueWithDelete = false;
                            }
                            else
                            {
                                Console.WriteLine("Option not found");
                            }
                        } while (continueWithDelete == true);
                    }
                    else if (mainOption == 4)
                    {
                        continueManaging = false;
                    }
                    else
                    {
                        Console.WriteLine("Option not found");
                    }

                } while (continueManaging == true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: {0}", ex.Message);
            }
        }

        private static void ShowAll()
        {
            Console.WriteLine("{0}All Customer Orders: {1}", Environment.NewLine, Environment.NewLine);
            DisplayCusomterOrders();

            Console.WriteLine("{0}All Customers: {1}", Environment.NewLine, Environment.NewLine);
            DisplayCusomter();

            Console.WriteLine("{0}All Items: {1}", Environment.NewLine, Environment.NewLine);
            DisplayItems();

            Console.WriteLine();
        }

        private static void ShowOrders()
        {
            Console.WriteLine("{0}All Customer Orders: {1}", Environment.NewLine, Environment.NewLine);
            DisplayCusomterOrders();

            Console.WriteLine();
        }

        private static void ShowCustomers()
        {
            Console.WriteLine("{0}All Customers: {1}", Environment.NewLine, Environment.NewLine);
            DisplayCusomter();

            Console.WriteLine();
        }

        private static void ShowItems()
        {
            Console.WriteLine("{0}All Items: {1}", Environment.NewLine, Environment.NewLine);
            DisplayItems();

            Console.WriteLine();
        }

        private static void DisplayItems()
        {
            IList<ItemModel> items = _itemCommand.GetList();

            if (items.Any())
            {
                foreach (ItemModel item in items)
                {
                    Console.WriteLine("(Item Id: {0}) Description: {1}, Price: {2}", item.ItemId, item.Description, item.Price);
                }
            }
        }

        private static void DisplayCusomter()
        {
            IList<CustomerModel> customers = _customerCommand.GetList();

            if (customers.Any())
            {
                foreach (CustomerModel customer in customers)
                {
                    Console.WriteLine("(Customer Id: {0}) First Name: {1}, Middle Name: {2}, Last Name: {3}, Age: {4}",
                        customer.CustomerId,
                        customer.FirstName,
                        customer.MiddleName ?? "N/A",
                        customer.LastName,
                        customer.Age);
                }
            }
        }

        private static void DisplayCusomterOrders()
        {
            IList<CustomerOrderDetailModel> customersOrderDetails = _customerOrderCommand.GetList();

            if (customersOrderDetails.Any())
            {
                foreach (CustomerOrderDetailModel customerOrderDetail in customersOrderDetails)
                {
                    Console.WriteLine("(Order Id: {0}) Customer: {1} {2} (Id: {3}) - purchased {4} for {5} (Id: {6})",
                        customerOrderDetail.CustomerOrderId,
                        customerOrderDetail.FirstName,
                        customerOrderDetail.LastName,
                        customerOrderDetail.CustomerId,
                        customerOrderDetail.Description,
                        customerOrderDetail.Price,
                        customerOrderDetail.ItemID);
                }
            }
        }

        private static void UpsertCustomerOrder(string userId)
        {
            Console.WriteLine("Note: For updating insert existing CustomerOrderId, for new entires enter -1.");

            Console.WriteLine("Enter CustomerOrderId:");
            int newCustomerOrderId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter CustomerId:");
            int newCustomerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter ItemId:");
            int newItemId = Convert.ToInt32(Console.ReadLine());

            _customerOrderCommand.Upsert(newCustomerOrderId, newCustomerId, newItemId, userId);
        }

        private static void UpsertCustomer(string userId)
        {
            Console.WriteLine("Note: For updating insert existing CustomerId, for new entires enter -1.");

            Console.WriteLine("Enter CustomerId:");
            int newCustomerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter First Name:");
            string newCustomerFirstName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Middle Name:");
            string newCustomerMiddleName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Last Name:");
            string newCustomerLastName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Customer Age:");
            int newCustomerAge = Convert.ToInt32(Console.ReadLine());

            _customerCommand.Upsert(newCustomerId, newCustomerFirstName, newCustomerMiddleName ?? "N/A", newCustomerLastName, newCustomerAge, userId);
        }

        private static void UpsertItem(string userId)
        {
            Console.WriteLine("Note: For updating insert existing ItemId, for new entires enter -1.");

            Console.WriteLine("Enter ItemId:");
            int newItemId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Description:");
            string newItemDescription = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Price:");
            decimal newItemPrice = Convert.ToDecimal(Console.ReadLine());

            _itemCommand.Upsert(newItemId, newItemDescription, newItemPrice, userId);
        }


        private static void DeleteCustomerOrder(string userId)
        {
            Console.WriteLine("Enter CustomerOrderId:");
            int customerOrderId = Convert.ToInt32(Console.ReadLine());

            _customerOrderCommand.Delete(customerOrderId, userId);
        }

        private static void DeleteCustomer(string userId)
        {
            Console.WriteLine("Enter CustomerId:");
            int customerId = Convert.ToInt32(Console.ReadLine());

            _customerCommand.Delete(customerId, userId);
        }

        private static void DeleteItem(string userId)
        {
            Console.WriteLine("Enter ItemId:");
            int itemId = Convert.ToInt32(Console.ReadLine());

            _itemCommand.Delete(itemId, userId);
        }
    }
}