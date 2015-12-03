using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Class_Layer.Utility_Classes;
using Class_Layer.Enums;

namespace Unit_Tests
{
    [TestClass]
    public class UtilitiesTest
    {
        [TestMethod]
        public void DateConversion()
        {
            //Roep methode aan om tijd naar OracleString om te zetten
            string time = ConvertTo.OracleDateTime(DateTime.Now);
            //Geef de geaccepteerde formats op voor de tryparse
            string[] formats = { "d-MMM-yyyy HH:mm:ss" };
            //Memory dump
            DateTime expectedDate;
            //TryParse de string, kijk of de string ook daadwerkelijk naar deze format is omgezet
            if (!DateTime.TryParseExact(time, formats, new CultureInfo("en-US"),
                                        DateTimeStyles.None, out expectedDate))
            {
                Assert.Fail("Date was not in right format");
            }
        }

        [TestMethod]
        public void EnumConversion()
        {
            string statusFromDatabase = "1";
            Status s;
            if (!Enum.TryParse(statusFromDatabase, out s))
            {
                Assert.Fail("Could not parse status");
            }
            if (s.ToString() != Status.Aangenomen.ToString())
            {
                Assert.Fail("Status has wrong name / failed to compare names");
            }
        }
    }
}
