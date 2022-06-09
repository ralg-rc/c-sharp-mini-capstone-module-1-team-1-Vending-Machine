using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        public Drink(string slotID, string name, decimal price) : base(slotID, name, price)
        {
            Sound = "Slurp Slurp, Yum!";
        }
    }
}
