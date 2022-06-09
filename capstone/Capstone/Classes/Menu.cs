using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public static class Menu
    {
        public static void MainMenu()
        {
            // Select menu option
            Console.WriteLine("1) Display Vending Machine Items");
            Console.WriteLine("2) Purchase");
            Console.WriteLine("3) Exit");
            Console.WriteLine("Make your selection:");
            Console.ReadLine();

        }
        public static void PurchaseMenu()
        {
            // Select menu option
            Console.WriteLine("1) Feed Money");
            Console.WriteLine("2) Select Product");
            Console.WriteLine("3) Finish Transaction");
            Console.WriteLine("Make your selection:");
            Console.ReadLine();

        }
    }
}
