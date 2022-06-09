using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace Capstone

{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine VM = new VendingMachine();
            VM.PopulateItemCollection();

            //foreach (Item item in VM.ItemCollection)
            //{
            //    Console.WriteLine($"{item.SlotID}, {item.Name}, ${item.Price}, ({item.Remaining})");
            //}


            VM.AcceptCash();
            VM.SpendCash();

            Console.WriteLine();
             Menu.MainMenu();
            
            
            
          
        }
    }
}
