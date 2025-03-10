using System;

namespace PotaytongNaKorner
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageUser userManager = new ManageUser();
            ManageProduct productManager = new ManageProduct();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║        POTAYTONG NA KORNER           ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Register                          ║");
                Console.WriteLine("║ 2. Login                             ║");
                Console.WriteLine("║ 3. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.ResetColor();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    if (userManager.Register(username, password))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Registration successful!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Failed to register. Username might already exist.");
                    }
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    if (userManager.Login(username, password))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login successful!");
                        Console.ResetColor();
                        Console.ReadKey();
                        ProductMenu(productManager);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid username or password.");
                        Console.ResetColor();
                    }
                    Console.ReadKey();
                }
                else if (choice == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Thank you for using Potaytong na Korner!");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        static void ProductMenu(ManageProduct productManager)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║          PRODUCT MANAGEMENT          ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Add Product                       ║");
                Console.WriteLine("║ 2. View Products                     ║");
                Console.WriteLine("║ 3. Logout                            ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.ResetColor();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal productPrice))
                    {
                        productManager.InsertProduct(productName, productPrice);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product added successfully!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid price format.");
                    }
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    productManager.DisplayProducts();
                    Console.ReadKey();
                }
                else if (choice == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Logging out...");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}
