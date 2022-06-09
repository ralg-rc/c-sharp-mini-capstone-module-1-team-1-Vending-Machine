using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : Item
    {

        public Candy(string slotID, string name, decimal price) : base(slotID, name, price)
        {
            Sound = "Munch Munch, Yum!";
        }

    }
}
