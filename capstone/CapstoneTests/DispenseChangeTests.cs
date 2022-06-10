using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class DispenseChangeTests
    {
        

        [TestMethod]
        public void DispenseQuarters_MakeQuarters()
        {
            decimal changeCash = 20;
            int result = (int)Math.Floor(changeCash / .25M);
            int expected = 80;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DispenseQuarters_Success()
        {
            decimal changeCash = 20;
            int amountOfQuarters = (int)Math.Floor(changeCash / .25M);

            decimal result = changeCash - (amountOfQuarters * .25M);
            decimal expected = 0;
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DispenseDimes_MakeDimes()
        {
            decimal changeCash = 20;

            int result = (int)Math.Floor(changeCash / .10M);
            int expected = 200;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DispenseDimes_Success()
        {
            decimal changeCash = 20;
            int amountOfDimes = (int)Math.Floor(changeCash / .10M);

            decimal result = changeCash - (amountOfDimes * .10M);
            decimal expected = 0;

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DispenseNickles_MakeNickles()
        {
            decimal changeCash = 20;

            int result = (int)Math.Floor(changeCash / .05M);
            int expected = 400;

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DispenseNickles_Successs()
        {
            decimal changeCash = 20;
            int amountOfNickles = (int)Math.Floor(changeCash / .05M);

            decimal result = changeCash - (amountOfNickles * 0.05M);
            decimal expected = 0;

            Assert.AreEqual(expected, result);
        }

    }
}
