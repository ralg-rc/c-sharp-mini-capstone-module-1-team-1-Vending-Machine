using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public List<Item> ItemCollection = new List<Item>();

        public VendingMachine() { }

        public decimal CurrentCash { get; private set; }

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
        public void AcceptCash()
        {
            decimal userCash = 0;
            try
            {
                Console.WriteLine("Please deposit cash");
                userCash = decimal.Parse(Console.ReadLine());
                CurrentCash += userCash;
                Console.WriteLine("Thank you");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine(ex.Message);
                AcceptCash();
            }
            catch (Exception ex)//add wrong type exeption
            {
                Console.WriteLine(ex.Message);
                AcceptCash();
            }

            // user log here 
            #region Log
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt"))

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
        public void DispenseChange()
        {
            // add change calculator
            Console.WriteLine($"Your change is {CurrentCash}"); // result of change calculator
            CurrentCash = 0.00M;
            // user log here 
        }
        public void SpendCash()
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

            if (doesConstain) //make invalid slot excpetion
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
                            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\AppData\Local\Temp\SalesLog.txt"))

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
                        //return to menu
                    }
                }
                else
                {
                    Console.WriteLine("out of stock");
                    //return menu
                }
            }
            else
            {
                Console.WriteLine("Doesn't exist");
                //return menu
            }
        }

    }

}

