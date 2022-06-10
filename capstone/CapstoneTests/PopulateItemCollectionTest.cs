using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;


namespace CapstoneTests
{
    [TestClass()]
    public class PopulateItemCollectionTest
    {
        [TestMethod]
        public void PopulateItemCollectionTest_Normal()
        {
            //ACT
            VendingMachine vendingMachineTest = new VendingMachine();
            //ARRANGE
            List<Item> testList = new List<Item>();
            testList.Add(new Chip("A1", "Potato Crisps", 3.05M));
            testList.Add(new Chip("A2", "Stackers", 1.45M));
            testList.Add(new Chip("A3", "Grain Waves", 2.75M));
            testList.Add(new Chip("A4", "Cloud Popcorn", 3.65M));
            testList.Add(new Candy("B1", "Moonpie", 1.80M));
            testList.Add(new Candy("B2", "Cowtales", 1.50M));
            testList.Add(new Candy("B3", "Wonka Bar", 1.50M));
            testList.Add(new Candy("B4", "Crunchie", 1.75M));
            testList.Add(new Drink("C1", "Cola", 1.25M));
            testList.Add(new Drink("C2", "Dr. Salt", 1.50M));
            testList.Add(new Drink("C3", "Mountain Melter", 1.50M));
            testList.Add(new Drink("C4", "Heavy", 1.50M));
            testList.Add(new Gum("D1", "U-Chews", 0.85M));
            testList.Add(new Gum("D2", "Little League Chew", 0.95M));
            testList.Add(new Gum("D3", "Chiclets", 0.75M));
            testList.Add(new Gum("D4", "Triplemint", 0.75M));
            vendingMachineTest.PopulateItemCollection();
            //ASSERT
            //Assert.AreEqual(testList, VendingMachine.ItemCollection);
            CollectionAssert.AreEqual(testList, VendingMachine.ItemCollection);
        }
    }
}
