using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace CapstoneTests
{
    [TestClass()]
    public class AcceptCashTests
    {
        [TestMethod]
        public void Accepts_Positive_Amount()
        {
            //ARRANGE
            VendingMachine.CurrentCash = 100;
            decimal deposit = 1M;
            //ACT
            VendingMachine.AcceptCash(deposit);
            decimal actual = VendingMachine.CurrentCash;
            //ASSERT
            Assert.AreEqual(101, actual);
        }

        //This test calls a Menu method. This then requires a user input, thus, it will not compile the test.
        //[TestMethod]
        //public void Negative_Amount_Does_Not_Change_CurrentCash()
        //{
        //    VendingMachine VM = new VendingMachine();
        //    VM.PopulateItemCollection();
        //    //ARRANGE
        //    VendingMachine.CurrentCash = 100;
        //    decimal deposit = -1M;
        //    //ACT
        //    VendingMachine.AcceptCash(deposit);
        //    decimal actual = VendingMachine.CurrentCash;
        //    //ASSERT
        //    Assert.AreEqual(100, actual);
        //}
    }
}