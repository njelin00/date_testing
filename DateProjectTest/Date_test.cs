using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateProject;

namespace DateProjectTest
{
    [TestClass]
    public class Date_test
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestNegativeNumberInDate()
        {
            var wallet = new Date(-3, 23, 2011);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestZeroInMonth()
        {
            var wallet = new Date(31, 0, 2014);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestUnknownMonth()
        {
            var wallet = new Date(11, 13, 2007);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestNumberOfDaysInMonth_TooBig()
        {
            var wallet = new Date(31, 4, 2014);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestNumberOfDaysInFebruary_TooBig()
        {
            var wallet = new Date(29, 2, 2014);
        }


        [TestMethod]
        public void TestGetMonth()
        {
            var date = new Date();
            Assert.AreEqual("April", date.getMonthName(4), "Pogreska u izracunu mjeseca!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestGetMonthError()
        {
            var date = new Date();
            string name = date.getMonthName(13);
        }

        [TestMethod]
        public void TestGetMonth1()
        {
            var datum = new Date(7, 1, 2013);
            Assert.AreEqual("January",datum.getMonthName(),"Pogreška u dohvatu mjeseca!");
        }

        [TestMethod]
        public void TestGetNumberOfRemainingDays()
        {
            var date = new Date();
            Assert.AreEqual(29,date.getNumberOfRemaingDaysInMonth(2, 5),"Pogreska u izracunu preostalih dana!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestGetNumberOfDaysInFebruary_Error()
        {
            var date = new Date();
            int number = date.getNumberOfRemaingDaysInMonth(2, 2);
        }

        [TestMethod]
        public void TestGetNumberOfRemainingDays_WithDate()
        {
            var date = new Date(2, 2, 2015);
            Assert.AreEqual(26, date.getNumberOfRemaingDaysInMonth(), "Pogreska u izracunu preostalih dana!");
        }

        [TestMethod]
        public void TestGetNumberOfRemainingDays_WithDate_LeapYear()
        {
            var date = new Date(2, 2, 2008);
            Assert.AreEqual(27, date.getNumberOfRemaingDaysInMonth(), "Pogreska u izracunu preostalih dana!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestGetNumberOfDays_ErrorTooMuchDays()
        {
            var date = new Date();
            int number = date.getNumberOfRemaingDaysInMonth(29, 2, 2014);
        }


        [TestMethod]
        public void TestIsLeapYear_NotLeapYear()
        {
            var date = new Date();
            Assert.AreEqual(false,date.isLeapYear(2015), "Pogreska u izracunu prijestupne godine");
        }

        [TestMethod]
        public void TestIsLeapYear_LeapYear()
        {
            var date = new Date();
            Assert.AreEqual(true, date.isLeapYear(2012), "Pogreska u izracunu prijestupne godine");
        }

        [TestMethod]
        public void TestIsLeapYear_Leap400()
        {
            var date = new Date();
            Assert.AreEqual(true, date.isLeapYear(2000), "Pogreska u izracunu prijestupne godine");
        }

        [TestMethod]
        public void TestIsLeapYear_NotLeapYear1()
        {
            var date = new Date(2, 2, 2014);
            Assert.AreEqual(false, date.isLeapYear(), "Pogreska u izracunu prijestupne godine");
        }

        [TestMethod]
        public void TestIsLeapYear_LeapYear1()
        {
            var date = new Date(2, 2, 2012);
            Assert.AreEqual(true, date.isLeapYear(), "Pogreska u izracunu prijestupne godine");
        }

        [TestMethod]
        public void TestIsLeapYear_Leap400_1()
        {
            var date = new Date(2, 2, 2000);
            Assert.AreEqual(true, date.isLeapYear(), "Pogreska u izracunu prijestupne godine");
        }

        [TestMethod]
        public void TestGetNumberOfRemainingDays_WithYear()
        {
            var date = new Date();
            Assert.AreEqual(26, date.getNumberOfRemaingDaysInMonth(2, 2, 2014), "Pogreska u izracunu preostalih dana!");
        }

        [TestMethod]
        public void TestGetNumberOfRemainingDays_WithLeapYear()
        {
            var date = new Date();
            Assert.AreEqual(27, date.getNumberOfRemaingDaysInMonth(2, 2, 2012), "Pogreska u izracunu preostalih dana!");
        }
    }
}