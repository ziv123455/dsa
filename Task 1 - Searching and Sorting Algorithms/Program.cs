using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager();

            int choice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose an Option:");
                Console.WriteLine("1. View Orders");
                Console.WriteLine("2. Search Orders");
                Console.WriteLine("3. View Most Urgent Orders");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("\nSelect an Option to Sort Orders:");
                            Console.WriteLine("1. Sort by Order ID (QuickSort)");
                            Console.WriteLine("2. Sort by Placed On Date (MergeSort)");
                            Console.WriteLine("3. Custom Sort (Implemented)");
                            Console.Write("Choice: ");

                            if (!int.TryParse(Console.ReadLine(), out int sortChoice) || sortChoice < 1 || sortChoice > 3)
                            {
                                Console.WriteLine("Invalid sort choice. Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }

                            try
                            {
                                List<Order> sortedOrders = orderManager.SortOrders(sortChoice);

                                Console.WriteLine("\nSorted Orders:\n");
                                foreach (Order order in sortedOrders)
                                {
                                    Console.WriteLine(order);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }

                            Console.WriteLine("\nPress any key to return to the main menu...");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        {
                            Console.Write("\nEnter Order ID to search: ");
                            string orderID = Console.ReadLine();

                            try
                            {
                                Order foundOrder = orderManager.GetOrderByID(orderID);
                                if (foundOrder != null)
                                {
                                    Console.WriteLine("\nOrder Found:");
                                    Console.WriteLine(foundOrder);
                                }
                                else
                                {
                                    Console.WriteLine("\nNo Order Found with that ID.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nInvalid Order ID format.");
                            }

                            Console.WriteLine("\nPress any key to return to the main menu...");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("\nListing 5 Most Urgent Orders:\n");

                            List<Order> urgentOrders = orderManager.GetMosturgentOrders();

                            if (urgentOrders == null || urgentOrders.Count == 0)
                            {
                                Console.WriteLine("No urgent orders found or PriorityQueue not implemented.");
                            }
                            else
                            {
                                foreach (Order order in urgentOrders)
                                {
                                    Console.WriteLine(order);
                                }
                            }

                            Console.WriteLine("\nPress any key to return to the main menu...");
                            Console.ReadKey();
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("\nExiting...");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("\nInvalid Option Selected. Press any key to try again...");
                            Console.ReadKey();
                        }
                        break;
                }
            } while (choice != 4);
        }
    }
}
