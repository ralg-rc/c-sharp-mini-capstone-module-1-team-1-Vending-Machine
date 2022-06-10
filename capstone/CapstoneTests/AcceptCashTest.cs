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
            VendingMachine.IsTesting = true;
            //ARRANGE
            VendingMachine.CurrentCash = 100;
            decimal deposit = 1M;
            //ACT
            VendingMachine.AcceptCash(deposit);
            decimal actual = VendingMachine.CurrentCash;
            //ASSERT
            Assert.AreEqual(101, actual);
        }
        [TestMethod]
        public void Negative_Amount_Does_Not_Change_CurrentCash()
        {
            VendingMachine.IsTesting = true;
            //ARRANGE
            VendingMachine.CurrentCash = 100;
            decimal deposit = -1M;
            //ACT
            VendingMachine.AcceptCash(deposit);
            decimal actual = VendingMachine.CurrentCash;
            //ASSERT
            Assert.AreEqual(100, actual);
        }
        [TestMethod]
        public void Zero_Amount_Does_Not_Change_CurrentCash()
        {
            VendingMachine.IsTesting = true;
            //ARRANGE
            VendingMachine.CurrentCash = 100;
            decimal deposit = 0M;
            //ACT
            VendingMachine.AcceptCash(deposit);
            decimal actual = VendingMachine.CurrentCash;
            //ASSERT
            Assert.AreEqual(100, actual);
        }
    }
}