using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public static class Menu
    {
       
        public static void MainMenu()
        {
            #region Select menu option
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("Make your menu selection:");
            int menuOption = 0;
            try
            {
                menuOption = int.Parse(Console.ReadLine());
            }
            //catch for invalid numbrs
            catch (FormatException)
            {
                Console.WriteLine("invalid menu\n");
                MainMenu();
            }
            catch
            {

            }
            #endregion

            if (menuOption == 1)
            {
                foreach (Item item in VendingMachine.ItemCollection)
                {
                    Console.WriteLine($"{item.SlotID}, {item.Name}, ${item.Price}, ({item.Remaining})");

                }
                MainMenu();
            }
            else if (menuOption == 2)
            {
                PurchaseMenu();
            }
            else if (menuOption == 3)
            {
                Console.WriteLine("bye");
            }
            else
            {
                Console.WriteLine("real plz");
                MainMenu();

            }
        } 
        public static void PurchaseMenu()
        {
            // Select menu option
            Console.WriteLine("");
            Console.WriteLine($"current money {VendingMachine.CurrentCash}\n");
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("Make your menu selection:");
            int purchaseOption = 0;
            //catch for invalid numbrs
            try
            {
                purchaseOption = int.Parse(Console.ReadLine());
            }
            catch  (FormatException)
            {
                Console.WriteLine("invalid menu \n");
                PurchaseMenu();
            }
            catch
            {

            }

            if (purchaseOption == 1)
            {
                VendingMachine.AcceptCash();
                PurchaseMenu();
            }
            else if (purchaseOption == 2)
            {
                VendingMachine.SpendCash();
                PurchaseMenu();

            }
            else if (purchaseOption == 3)
            {
                //change
                MainMenu();
            }
            else
            {
                Console.WriteLine("real plz");
                PurchaseMenu();

            }

        }
    }
}
