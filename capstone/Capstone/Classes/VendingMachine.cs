using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //make pretty

        //PROPERTIES
        public static List<Item> ItemCollection = new List<Item>();
        public static decimal CurrentCash { get; private set; }

       
        //CONSTRUCTORS
        public VendingMachine() 
        {
            try
            {
                using (StreamWriter mainSW = new StreamWriter(File.Create(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt")));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {

            }
        }

        //METHODS
        public void PopulateItemCollection()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-1\capstone\vendingmachine.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] propertyArray = line.Split(",");
                        if (propertyArray[3] == "Chip")
                        {
                            ItemCollection.Add(new Chip(propertyArray[0], propertyArray[1], decimal.Parse(propertyArray[2])));
                        }
                        else if (propertyArray[3] == "Candy")
                        {
                            ItemCollection.Add(new Candy(propertyArray[0], propertyArray[1], decimal.Parse(propertyArray[2])));
                        }
                        else if (propertyArray[3] == "Drink")
                        {
                            ItemCollection.Add(new Drink(propertyArray[0], propertyArray[1], decimal.Parse(propertyArray[2])));
                        }
                        else if (propertyArray[3] == "Gum")
                        {
                            ItemCollection.Add(new Gum(propertyArray[0], propertyArray[1], decimal.Parse(propertyArray[2])));
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        } //done
        public static void AcceptCash()
        {
            decimal userCash = 0;
            Console.Clear();
            Console.WriteLine($"Your balance: ${CurrentCash}\n");
            try
            {
                Console.WriteLine("Please deposit cash");
                userCash = int.Parse(Console.ReadLine());
                if (userCash > 0)
                {
                    CurrentCash += userCash;
                    Console.Clear();
                    Console.WriteLine("Thank you");

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number");
                    AcceptCash();
                }
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number");
                AcceptCash();
            }
            catch(FormatException ex)
            {
                Console.Clear();
                Console.WriteLine("Whole bills only please");
                AcceptCash();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AcceptCash();
            } 

            #region Log
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt",true))

                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY: {userCash} {CurrentCash}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
        } //done
        public static void DispenseChange()
        {
            #region Main


            decimal changeCash = CurrentCash ;
            int amountOfQuarters;
            int amountOfDimes;
            int amountOfNickels;     

            amountOfQuarters = (int)Math.Floor(changeCash / .25M);
            changeCash -= amountOfQuarters * .25M;
            amountOfDimes = (int)Math.Floor(changeCash / .10M);
            changeCash -= amountOfDimes * .10M;
            amountOfNickels = (int)Math.Floor(changeCash / .05M);
            changeCash -= amountOfNickels * .05M;

            Console.Clear();
            Console.WriteLine($"Your change is ${CurrentCash}");
            Console.WriteLine($"Your Quarters:{amountOfQuarters}\nYour Dimes:{amountOfDimes}\nYour Nickles:{amountOfNickels}\n");
            #endregion

            #region Log
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt", true))

                {
                    sw.WriteLine($"{DateTime.Now} GIVE CHANGE: ${CurrentCash} ${changeCash}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            CurrentCash = 0;
        } //done
        public static void SpendCash()
        {

            Console.WriteLine("Please enter a slot ID");

            #region Determine slot existance
            string answer = Console.ReadLine().ToUpper();
            bool doesConstain = false;
            int searchedItemIndex = 0;
            foreach (Item item in ItemCollection)
            {
                if (item.SlotID == answer)
                {
                    doesConstain = true;
                }
                if (doesConstain)
                {
                    searchedItemIndex = ItemCollection.IndexOf(item);
                    break;
                }

            }
            #endregion


            if (doesConstain)
            {
                if (!ItemCollection[searchedItemIndex].isOutofStock)
                {
                    if (CurrentCash - ItemCollection[searchedItemIndex].Price >= 0)
                    {
                        CurrentCash = CurrentCash - ItemCollection[searchedItemIndex].Price;
                        Console.Clear();
                        Console.WriteLine($"Here's your {ItemCollection[searchedItemIndex].Name}! {ItemCollection[searchedItemIndex].Sound} ");

                        ItemCollection[searchedItemIndex].Remaining--;


                    #region Log
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt",true))

                            {
                                sw.WriteLine($"{DateTime.Now} {ItemCollection[searchedItemIndex].Name} {ItemCollection[searchedItemIndex].SlotID} {ItemCollection[searchedItemIndex].Price} {CurrentCash}");
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        #endregion

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Insufficient funds");
                        Menu.PurchaseMenu();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This item is out of stock");
                    Menu.PurchaseMenu();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid slot ID");
                Menu.PurchaseMenu();
            }
        } //done
    }
}

