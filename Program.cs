using System;

namespace asm
{
    internal class Program
    {
        const int MAX_Customer = 100;
        static string[] nameCustomer = new string[MAX_Customer];
        static double[] Totalbill = new double[MAX_Customer];
        static int customerCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("                          Hello!                               ");
                Console.WriteLine("************************************************************   ");
                Console.WriteLine("**************** Welcome to Calculate Water! ***************   ");
                showMenu();
                Console.Write("     Enter your choice is: ");
                if (!int.TryParse(Console.ReadLine(), out int Choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (Choice)
                {
                    case 1:
                        Console.WriteLine("     *************************************************   ");
                        Console.WriteLine("     ******* Welcome to Calculate Bill Water! ********   ");
                        Console.WriteLine("     -------------------------------------------------   ");
                        nameConsumed();
                        TotalBill();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("     **************************************************   ");
                        Console.WriteLine("     *** Welcome to search for customer information ***   ");
                        Console.WriteLine("     --------------------------------------------------   ");
                        SearchInfor();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        static void showMenu() //Show Menu 
        {
            Console.WriteLine("     -------------------------------------------------     ");
            Console.WriteLine("     | What do you need help with?                   |     ");
            Console.WriteLine("     -------------------------------------------------     ");
            Console.WriteLine("     | 1. Calculater bill water                      |     ");
            Console.WriteLine("     | 2. Search for customer information            |     ");
            Console.WriteLine("     | 3. Exit                                       |     ");
            Console.WriteLine("     -------------------------------------------------     ");
        }

        static void TypeOfCustomer() //Show Menu Type customer
        {
            Console.WriteLine("     -------------------------------------------------");
            Console.WriteLine("     | Type of customer:                             |");
            Console.WriteLine("     -------------------------------------------------");
            Console.WriteLine("     | 1. Family                                     |");
            Console.WriteLine("     | 2. Administrative and public services         |");
            Console.WriteLine("     | 3. Production units                           |");
            Console.WriteLine("     | 4. Business services                          |");
            Console.WriteLine("     | 5. Exit                                       |");
            Console.WriteLine("     -------------------------------------------------");
        }

        static void nameConsumed()
        {
            if (customerCount >= MAX_Customer)
            {
                Console.WriteLine("Array is full, cannot add customers.");
                return;
            }
            Console.WriteLine("     What is your name? ");
            Console.Write("     Your name is: ");
            nameCustomer[customerCount] = Console.ReadLine();
        }

        static void TotalBill()
        {
            const double PRICE_LEVEL_1 = 5.973;
            const double PRICE_LEVEL_2 = 7.052;
            const double PRICE_LEVEL_3 = 8.699;
            const double PRICE_LEVEL_4 = 15.929;
            const double PRICE_FOR_AGENCIES = 9.955;
            const double PRICE_FOR_PRODUCTION = 11.615;
            const double PRICE_FOR_BUSINESS = 22.068;
            double price = 0;

            Console.WriteLine("     -------------------------------------------------     ");
            Console.Write("     Enter the last month water meter: ");
            if (!double.TryParse(Console.ReadLine(), out double LMW))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.Write("     Enter this month water number: ");
            if (!double.TryParse(Console.ReadLine(), out double TMW))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            double Consumed = TMW - LMW;
            while (Consumed < 0)
            {
                Console.WriteLine("     Error!. Please re-enter");
                Console.Write("     Enter the last month water meter: ");
                if (!double.TryParse(Console.ReadLine(), out LMW))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    return;
                }

                Console.Write("     Enter the this month water meter: ");
                if (!double.TryParse(Console.ReadLine(), out TMW))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    return;
                }

                Consumed = TMW - LMW;
            }

            Console.WriteLine("     --------------------------------------         ");
            Console.WriteLine("     Your water consumption is: " + Consumed + " m3");

            TypeOfCustomer();
            Console.Write("     Your choice is: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            switch (choice)
            {
                case 1:
                    if (Consumed <= 10)
                    {
                        price = Consumed * PRICE_LEVEL_1;
                    }
                    else if (Consumed <= 20)
                    {
                        price = (10 * PRICE_LEVEL_1) + (Consumed - 10) * PRICE_LEVEL_2;
                    }
                    else if (Consumed <= 30)
                    {
                        price = (10 * PRICE_LEVEL_1) + (10 * PRICE_LEVEL_2) + (Consumed - 20) * PRICE_LEVEL_3;
                    }
                    else
                    {
                        price = (10 * PRICE_LEVEL_1) + (10 * PRICE_LEVEL_2) + (10 * PRICE_LEVEL_3) + (Consumed - 30) * PRICE_LEVEL_4;
                    }
                    break;
                case 2:
                    price = Consumed * PRICE_FOR_AGENCIES;
                    break;
                case 3:
                    price = Consumed * PRICE_FOR_PRODUCTION;
                    break;
                case 4:
                    price = Consumed * PRICE_FOR_BUSINESS;
                    break;
                case 5:
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("     Invalid selection.");
                    return;
            }

            double environmentFee = price * 0.1;
            double bill = price + environmentFee;
            double VAT = bill * 0.1;
            Totalbill[customerCount] = bill + VAT;

            Console.WriteLine("     --------------------------Water Bill-----------------------------  ");
            Console.WriteLine("     Amount of water consumed:                       "+ Consumed + "m3  ");
            Console.WriteLine("     Water fee is:                                   "+ price + "VND  ");
            Console.WriteLine("     Water fee including environment fee is:         "+ bill + "VND  ");
            Console.WriteLine("     -----------------------------------------------------------------  ");
            Console.WriteLine("     Total water bill payable is:                    "+ Totalbill[customerCount] + "VND  ");
            Console.WriteLine("     -----------------------------------------------------------------  ");
            Console.WriteLine("     -------------------------- Thank you ----------------------------  ");



            customerCount++;
        }

        static void SearchInfor()
        {
            Console.Write("     Enter the name of the customer you want to search for: ");
            string searchName = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < customerCount; i++)
            {
                if (string.Equals(nameCustomer[i].ToLower(), searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("     -----------------------------------------------------------------  ");
                    Console.WriteLine("     Customer information:                             "+ nameCustomer[i]);
                    Console.WriteLine("     Total bill:                                       "+ Totalbill[i] + " VND");
                    Console.WriteLine("     -------------------------- Thank you ----------------------------  ");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("     Customer not found.");
            }
        }
    }
}
