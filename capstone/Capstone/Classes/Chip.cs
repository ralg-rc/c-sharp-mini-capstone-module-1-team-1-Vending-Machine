using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        public Chip(string slotID, string name, decimal price) : base(slotID, name, price)
        {
            Sound  = "Crunch Crunch, Yum!";
        }
    }
}
