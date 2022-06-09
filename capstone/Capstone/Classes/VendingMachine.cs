using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //add consosle.clear
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
            try
            {
                Console.WriteLine("Please deposit cash");
                userCash = int.Parse(Console.ReadLine());
                CurrentCash += userCash;
                Console.WriteLine("Thank you");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine(ex.Message);
                AcceptCash();
            }
            catch(FormatException ex)
            {
                Console.WriteLine("need whole nums");
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
            Console.WriteLine($"Your change is ${CurrentCash}");

            decimal changeCash = CurrentCash ;
            int amountOfQuarters;
            int amountOfDimes;
            int amountOfNickels;     

            amountOfQuarters = (int)Math.Floor(changeCash / .25M); //
            changeCash -= amountOfQuarters * .25M;
            amountOfDimes = (int)Math.Floor(changeCash / .10M);
            changeCash -= amountOfDimes * .10M;
            amountOfNickels = (int)Math.Floor(changeCash / .05M);
            changeCash -= amountOfNickels * .05M;

            Console.WriteLine($"Your Quarters:{amountOfQuarters}\nYour Dimes:{amountOfDimes}\nYour Nickles:{amountOfNickels}");
            CurrentCash = 0;
            #region Log
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt", true))

                {
                    sw.WriteLine($"{DateTime.Now} GIVE CHANGE: ${changeCash} ${CurrentCash}");
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
        public static void SpendCash()
        {
            Console.WriteLine("ask for ID");
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

            if (doesConstain) //make custom invalid slot excpetion
            {
                if (!ItemCollection[searchedItemIndex].isOutofStock)
                {
                    if (CurrentCash - ItemCollection[searchedItemIndex].Price >= 0)
                    {
                        CurrentCash = CurrentCash - ItemCollection[searchedItemIndex].Price;
                        Console.WriteLine($"here's your {ItemCollection[searchedItemIndex].Name}! {ItemCollection[searchedItemIndex].Sound} ");
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
                        Console.WriteLine("not enough $");
                        Menu.PurchaseMenu();
                    }
                }
                else
                {
                    Console.WriteLine("out of stock");
                    Menu.PurchaseMenu();
                }
            }
            else
            {
                Console.WriteLine("Doesn't exist");
                Menu.PurchaseMenu();
            }
        } //done
    }

}

