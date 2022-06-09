using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string SlotID { get; set; }
        public decimal Price { get; set; }
        public string Sound { get; set; }
        public int Remaining { get; set; } = 5;
        public bool isOutofStock
        {
            get
            {
                if (Remaining == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Item(string slotID, string name, decimal price)
        {
            SlotID = slotID;
            Name = name;
            Price = price;
            
        }
        public Item()
        {

        }


    }
}
