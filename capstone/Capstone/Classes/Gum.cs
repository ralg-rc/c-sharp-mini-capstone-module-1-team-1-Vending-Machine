using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Item 
    {
        public Gum(string slotID, string name, decimal price) : base(slotID, name, price)
        {
           Sound = "Chewy Chewy, Yum!";
        }
    }
}
