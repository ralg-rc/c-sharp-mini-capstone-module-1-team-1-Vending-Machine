using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public static class VendingMachine 
    {
        public static List<Item> ItemCollection = new List<Item>();
        public static decimal CurrentCash { get; private set; }


        public static void PopulateItemCollection()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-1\capstone"))
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
            catch
            {

            }

        }
        public static void AcceptCash()
        {
            try
            {
                Console.WriteLine("Please deposit cash");
                decimal userCash = decimal.Parse(Console.ReadLine());
                CurrentCash = CurrentCash + userCash;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Please enter a valid number");
            }
            // user log here 

        }
        public static void DispenseChange()
        {
            // add change calculator
            Console.WriteLine($"Your change is {CurrentCash}"); // result of change calculator
            CurrentCash = 0.00M;
            // user log here 
        }
        public static void SpendCash(Item item)
        {
            CurrentCash = CurrentCash - item.Price;
        }
        
    }
}
