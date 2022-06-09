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
            VendingMachine.PopulateItemCollection();
            Menu.MainMenu();
            
            
          
        }
    }
}
