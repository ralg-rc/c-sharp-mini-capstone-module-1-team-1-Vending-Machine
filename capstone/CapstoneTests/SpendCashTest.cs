using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass()]
    public class SpendCashTest
    {

        [TestMethod]
        public void SpendCashTest_Normal()
        {
            //ARRANGE

            VendingMachine.CurrentCash = 100;
            string testAnswer = "A2";

            //ACT
            //Console.WriteLine("");
            VendingMachine.SpendCash(testAnswer);
            //ASSERT
            Assert.AreEqual(4, VendingMachine.ItemCollection[1].Remaining);
            Assert.AreEqual(98.55M, VendingMachine.CurrentCash);
        }

        [TestMethod]
        public void SpendCashTest_InvalidSlot()
        {
            VendingMachine.IsTesting = true;
            //ARRANGE
            VendingMachine.CurrentCash = 100;
            string testAnswer = "A100";

            //ACT
            VendingMachine.SpendCash(testAnswer);
            //ASSERT
            Assert.AreEqual(5, VendingMachine.ItemCollection[1].Remaining);
            Assert.AreEqual(100, VendingMachine.CurrentCash);
        }

        [TestMethod]
        public void SpendCashTest_NoMoney()
        {
            VendingMachine.IsTesting = true;
            //ARRANGE
            VendingMachine.CurrentCash = 0;
            string testAnswer = "A2";

            //ACT
            VendingMachine.SpendCash(testAnswer);
            //ASSERT
            Assert.AreEqual(5, VendingMachine.ItemCollection[1].Remaining);
            Assert.AreEqual(0, VendingMachine.CurrentCash);
        }

        [TestMethod]
        public void SpendCashTest_OutOfStock()
        {
            VendingMachine.IsTesting = true;
            //ARRANGE
            VendingMachine.CurrentCash = 100;
            string testAnswer = "A2";

            //ACT
            VendingMachine.ItemCollection[1].Remaining = 0;
            VendingMachine.SpendCash(testAnswer);
            

            //ASSERT
            Assert.AreEqual(0, VendingMachine.ItemCollection[1].Remaining);
            Assert.AreEqual(100, VendingMachine.CurrentCash);
        }
    }
}
