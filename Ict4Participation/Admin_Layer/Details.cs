using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Class_Layer;

namespace Admin_Layer
{
    public abstract class Creation
    {
        public static Object getDetailsObject(Object o)
        {
            Object odetails = Activator.CreateInstance(Type.GetType("Admin_Layer." + o.GetType().Name + "details"));
            foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
            {
                foreach (PropertyInfo detailInfo in odetails.GetType().GetProperties())
                {
                    if (propertyInfo.Name == detailInfo.Name)
                    {
                        detailInfo.SetValue(odetails, propertyInfo.GetValue(o));
                        break;
                    }
                }
            }
            return odetails;
        }
    }

    public struct Meetingdetails
    {
        //
        public int PostID { get; set; }
        public int RequesterID { get; set; }
        public int PosterID { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
    }

    public struct Reviewdetails
    {
        //
        public int PostID { get; set; }
        public int PosterID { get; set; }
        public int Rating { get; set; }
        public int PostedToID { get; set; }
        public string Description { get; set; }
        //
        public override string ToString()
        {
            return Rating + "-ster: " + Description;
        }
    }

    public class Questiondetails
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public DateTime PostDate { get; set; }
        public string Description { get; set; }
        public bool Urgent { get; set; }
        public string Location { get; set; }
        public int AmountAccs { get; set; }
        public string Status { get; set; }
        public int PosterID { get; set; }
        private List<string> skills;
        public List<string> Skills
        {
            get { return skills; }
            set { skills = value; }
        }
        private List<int> volunteers;
        public List<int> Volunteers
        {
            get { return volunteers; }
            set { volunteers = value; }
        }

        public Questiondetails()
        {
            skills = new List<string>();
            volunteers = new List<int>();
        }
        public override string ToString()
        {
            return Title;
        }
    }

    public class Accountdetails
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phonenumber { get; set; }
        public Nullable<bool> hasDriverLicense { get; set; }
        public Nullable<bool> hasVehicle { get; set; }
        public DateTime Lastlogin { get; set; }
        public Nullable<bool> OVPossible { get; set; }
        public DateTime Birthdate { get; set; }
        public string AvatarPath { get; set; }
        public string VOGPath { get; set; }
        public string Gender { get; set; }
        private List<Availabilitydetails> availabilityDetailList;
        public List<Availabilitydetails> AvailabilityDetailList
        {
            get { return availabilityDetailList; }
            set { availabilityDetailList = value; }
        }
        private List<Skilldetails> skillsDetailList;
        public List<Skilldetails> SkillsDetailList
        {
            get { return skillsDetailList; }
            set { skillsDetailList = value; }
        }
        public Accountdetails()
        {
            availabilityDetailList = new List<Availabilitydetails>();
            skillsDetailList = new List<Skilldetails>();
        }
        public string Description { get; set; }

        public override string ToString()
        {
            return Username + ">> " + Name;
        }
    }

    public struct Availabilitydetails
    {
        public string Daytime { get; set; }
        public string Day { get; set; }
    }

    public struct Commentdetails
    {
        public int PostID { get; set; }
        public int PosterID { get; set; }
        public int PostedToID { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }

        // Added IsDeleted to see if comment has been deleted
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return PostID + ">> " + Description;
        }
    }

    public struct Skilldetails
    {
        public int UserID { get; set; }
        public string Name { get; set; }
    }

    public class QuestionAccountDetails
    {
        public int AccID { get; set; }
        public string AccName { get; set; }
        public int QueID { get; set; }
        public string QueName  { get; set; }
        public DateTime AcceptionDate { get; set; }
    }
}
