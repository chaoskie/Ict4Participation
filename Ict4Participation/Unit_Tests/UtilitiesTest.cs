using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Admin_Layer;
using Class_Layer;
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
            string status = s.ToString();

            if (status != Status.Aangenomen.ToString())
            {
                Assert.Fail("Status has wrong name / failed to compare names");
            }
        }

        [TestMethod]
        public void GetReviewDetails()
        {
            Review r = new Review(0, 3, 1, 2, "Ayyy lmao");
            Reviewdetails rd = (Reviewdetails)Creation.getDetailsObject(r);
            if (r.Description != rd.Description)
            {
                Assert.Fail("Failed to write Description properly");
            }
            if (r.PostedToID != rd.PostedToID)
            {
                Assert.Fail("Failed to write PostedToID properly");
            }
            if (r.Rating != rd.Rating)
            {
                Assert.Fail("Failed to write Rating properly");
            }
        }

        [TestMethod]
        public void GetAccountDetails()
        {
            List<Availability> availability = new List<Availability>()
            {
                new Availability(1, "Mo", "Ochtend"),
                new Availability(2, "Mo", "Avond"),
                new Availability(3, "Tu", "Avond")
            };

            List<Skill> skills = new List<Skill>()
            {
                new Skill(1, "Programming"),
                new Skill(1, "Logical thinking"),
                new Skill(1, "Working"),
                new Skill(1, "Driver experience")
            };
            Account a = new Account(
                1,
                "Biepbot",
                "Biepbot@gmail.com",
                "Rowan Dings",
                "Turfveldenstraat 12",
                "Eindhoven",
                "+31 0402920180",
                "0",
                "1",
                DateTime.Now,
                "1",
                DateTime.Now,
                "Avatar.png",
                "VOG.pdf",
                "Man",
                skills,
                availability, "");      
            Accountdetails ad = (Accountdetails)Creation.getDetailsObject(a);
            ad.AvailabilityDetailList = availability.Select(ava => Creation.getDetailsObject(ava)).Cast<Availabilitydetails>().ToList();
            ad.SkillsDetailList = skills.Select(ski => Creation.getDetailsObject(ski)).Cast<Skilldetails>().ToList();
            for (int i = 0; i < a.Availability.Count; i++ )
            {
                if (a.Availability[i].Day != ad.AvailabilityDetailList[i].Day)
                {
                    Assert.Fail("Failed to write Rating properly");
                }
                if (a.Availability[i].Daytime != ad.AvailabilityDetailList[i].Daytime)
                {
                    Assert.Fail("Failed to write Rating properly");
                }
                if (a.Skills[i].Name != ad.SkillsDetailList[i].Name)
                {
                    Assert.Fail("Failed to write Rating properly");
                }
                if (a.Skills[i].UserID != ad.SkillsDetailList[i].UserID)
                {
                    Assert.Fail("Failed to write Rating properly");
                }
            }
        }

        [TestMethod]
        public void RegexTest()
        {
            string s = "lol oke";
            s = s.Replace(" ", "");

            if (s != "loloke")
            {
                Assert.Fail();
            }
        }
    }
}
