using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public static class Menu
    {
       
        public static void MainMenu()
        {
            #region Input menu option
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("Please choose one of the above options:");
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
            Console.Clear();
            #endregion

            #region Navigate Menu

            if (menuOption == 1)
            {

                foreach (Item item in VendingMachine.ItemCollection)
                {
                    if (item.Remaining == 0)
                    {
                        Console.WriteLine($"Slot ID: ({item.SlotID}) {item.Name} - ${item.Price}, Remaining: Sold Out");
                    }
                    else
                    {
                        Console.WriteLine($"Slot ID: ({item.SlotID}) {item.Name} - ${item.Price}, Remaining: ({item.Remaining})");
                    }

                }
                Console.WriteLine();
                MainMenu();
            }
            else if (menuOption == 2)
            {
                Console.Clear();
                PurchaseMenu();
            }
            else if (menuOption == 3)
            {
                Console.Clear();
                Console.WriteLine("See you later, Space Cowboy...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection\n");
                MainMenu();

            }
            #endregion
        }

        public static void PurchaseMenu()
        {
            #region Input menu option
            Console.WriteLine($"Your balance: ${VendingMachine.CurrentCash}\n");
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("Please choose one of the above options:");
            int purchaseOption = 0;
            try
            {
                purchaseOption = int.Parse(Console.ReadLine());
            }
            catch  (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection\n");
                PurchaseMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            #endregion

            #region Navigate Menu
            if (purchaseOption == 1)
            {
                VendingMachine.AcceptCash();
                PurchaseMenu();
            }
            else if (purchaseOption == 2)
            {
                Console.Clear();
                foreach (Item item in VendingMachine.ItemCollection)
                {
                    if (item.Remaining == 0)
                    {
                        Console.WriteLine($"Slot ID: ({item.SlotID}) {item.Name} - ${item.Price}, Remaining: Sold Out");
                    }
                    else
                    {
                        Console.WriteLine($"Slot ID: ({item.SlotID}) {item.Name} - ${item.Price}, Remaining: ({item.Remaining})");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Your balance: ${VendingMachine.CurrentCash}");
                VendingMachine.SpendCash();
                PurchaseMenu();

            }
            else if (purchaseOption == 3)
            {
                VendingMachine.DispenseChange();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid Selection\n");
                PurchaseMenu();
            }
            #endregion
        }
    }
}
