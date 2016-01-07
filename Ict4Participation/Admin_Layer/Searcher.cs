using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Layer;

namespace Admin_Layer
{
    abstract class Searcher
    {
        /// <summary>
        /// Iterates through a list of accounts to yield the matching accounts
        /// </summary>
        /// <param name="Accounts">The accounts to iterate through</param>
        /// <param name="search">The search terms</param>
        /// <returns></returns>
        public static List<Accountdetails> Detailed(List<Account> Accounts, Accountdetails search)
        {
            if (search.Address == null) { search.Address = ""; }
            if (search.Username == null) { search.Username = ""; }
            if (search.Name == null) { search.Name = ""; }
            if (search.Email == null) { search.Email = ""; }
            if (search.City == null) { search.City = ""; }
            if (search.Phonenumber == null) { search.Phonenumber = ""; }

            //Search through all the details, where the details match
            List<Accountdetails> NoSkillSearchList = Accounts.Where(
                av => av.Address.Contains(search.Address) &&
                av.Username.Contains(search.Username) &&
                av.Name.Contains(search.Name) &&
                av.Email.Contains(search.Email) &&
                av.City.Contains(search.City) &&
                av.Phonenumber.Contains(search.Phonenumber) &&
                (search.hasDriverLicense != null ? av.hasDriverLicense == search.hasDriverLicense : av.hasDriverLicense != search.hasDriverLicense) && //If null, return both true and false
                (search.hasVehicle != null ? av.hasVehicle == search.hasVehicle : av.hasVehicle != search.hasVehicle) && //If null, return both true and false
                (search.OVPossible != null ? av.OVPossible == search.OVPossible : av.OVPossible != search.OVPossible) //If null, return both true and false
                ).Select(av => Creation.getDetailsObject(av))
                .Cast<Accountdetails>().ToList();

            return returnAccountDetails(NoSkillSearchList, Accounts, search);
        }

        /// <summary>
        /// Iterates through a list of accounts to yield the matching accounts
        /// </summary>
        /// <param name="Accounts">The accounts to iterate through</param>
        /// <param name="search">The search string</param>
        /// <returns></returns>
        public static List<Accountdetails> Global(List<Account> Accounts, string search)
        {
            if (search == null) { search = ""; }

            //Search through all the details, where the details match
            List<Accountdetails> NoSkillSearchList = Accounts.Where(
                av => av.Address.Contains(search) ||
                av.Username.Contains(search) ||
                av.Name.Contains(search) ||
                av.Email.Contains(search) ||
                av.City.Contains(search)
                ).Select(av => Creation.getDetailsObject(av))
                .Cast<Accountdetails>().ToList();

            return returnAccountDetails(NoSkillSearchList, Accounts, search);
        }

        /// <summary>
        /// Finalizes the search for accounts
        /// </summary>
        /// <param name="NoSkillSearchList">The list of accounts without skills</param>
        /// <param name="Accounts">The list of accounts with skills</param>
        /// <param name="search">The search terms</param>
        /// <returns></returns>
        private static List<Accountdetails> returnAccountDetails(List<Accountdetails> NoSkillSearchList, List<Account> Accounts, object search)
        {
            //add skill list for every account
            foreach (Accountdetails accd in NoSkillSearchList)
            {
                foreach (Account acc in Accounts)
                {
                    //Only if the ID's match
                    if (accd.ID == acc.ID)
                    {
                        //Add skills
                        foreach (Skill s in acc.Skills)
                        {
                            //As skilldetails
                            accd.SkillsDetailList.Add((Skilldetails)Creation.getDetailsObject(s));
                        }
                        break;
                    }
                }
            }
            //Remember a list of items to remove
            List<int> removables = new List<int>();

            //If the search is a string (global, no skill search), or detailed search object (skill search) 
            if (search is Accountdetails)
            { 

            //Search through the skills of these accounts
            foreach (Accountdetails acc in NoSkillSearchList)
            {
                //If an account with all the skills in the list of wanted skills exist
                //(ergo: if an account does not lack the skills)
                //Keep it
                if (acc.SkillsDetailList.Exists(skill => !((Accountdetails)search).SkillsDetailList.Contains(skill)))
                {
                    //STICKER FOR YOU <3
                }
                //Else, remove it
                else
                {
                    removables.Add(acc.ID);
                }
            }
            }

            //Add the accounts that do match properly to a new list
            List<Accountdetails> ReturnableList = new List<Accountdetails>();
            foreach (Accountdetails acc in NoSkillSearchList)
            {
                ReturnableList.AddRange(NoSkillSearchList.Where(a => !removables.Contains(a.ID)));
            }

            return ReturnableList;
        }

        /// <summary>
        /// Iterates through a list of questions to yield the matching questions
        /// </summary>
        /// <param name="Questions">The questions to iterate through</param>
        /// <param name="search">The search terms</param>
        /// <returns></returns>
        public static List<Questiondetails> Detailed(List<Question> Questions, Questiondetails search)
        {
            if (search.AmountAccs == null) { search.AmountAccs = 100; }
            if (search.Description == null) { search.Description = ""; }
            if (search.EndDate == null) { search.EndDate = DateTime.Now.AddYears(15); }
            if (search.StartDate == null) { search.StartDate = DateTime.Now.AddYears(-15); }
            if (search.Location == null) { search.Location = ""; }
            if (search.Title == null) { search.Title = ""; }

            //Search through all the details, where the details match
            List<Questiondetails> NoSkillSearchList = Questions.Where(
                qv => qv.AmountAccs <= search.AmountAccs &&
                qv.Description.Contains(search.Description) &&
                qv.EndDate <= search.EndDate &&
                qv.StartDate >= search.StartDate &&
                qv.Location.Contains(search.Location) &&
                qv.Title.Contains(search.Title) &&
                (search.Urgent != null ? qv.Urgent == search.Urgent : qv.Urgent != search.Urgent)
                ).Select(qv => Creation.getDetailsObject(qv))
                .Cast<Questiondetails>().ToList();


            //Remember a list of items to remove
            List<int> removables = new List<int>();

            //Search through the skills of these questions
            foreach (Questiondetails que in NoSkillSearchList)
            {
                //If a question with all the skills in the list of wanted skills exist
                //(ergo: if a question does not lack the skills)
                //Keep it
                if (que.Skills.Exists(skill => !search.Skills.Contains(skill)))
                {
                    //STICKER FOR YOU <3
                }
                //Else, remove it
                else
                {
                    removables.Add(que.PostID);
                }
            }

            //Add the accounts that do match properly to a new list
            List<Questiondetails> ReturnableList = new List<Questiondetails>();
            foreach (Questiondetails acc in NoSkillSearchList)
            {
                ReturnableList.AddRange(NoSkillSearchList.Where(a => !removables.Contains(a.PostID)));
            }

            return ReturnableList;
        }
    }
}
