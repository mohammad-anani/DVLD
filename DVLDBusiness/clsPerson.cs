using DVLD_data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsPerson
    {
        public enum enMode { Add,Update};
        public int Id { get; set; }
        public string NationalNO { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string ImagePath {  get; set; }  
        public enMode Mode { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.SecondName + " " + this.ThirdName + " " + this.LastName;
        }

        private clsPerson(int id,string first, string second, string third, string last, string nationalno,
            string phone, string email, string address, string countryid, string imagepath, DateTime dateofbirth, string gender)
        {
           this.Id = id;
           this.FirstName = first;
           this.SecondName = second;
           this.ThirdName = third;
           this.LastName = last;
           this.Email = email;
           this.Phone = phone;
           this.DateOfBirth = dateofbirth;
           this.Country = countryid;
           this.Address = address;
           this.ImagePath = imagepath;
           this.NationalNO = nationalno;
           this.Gender = gender;
           this.Mode = enMode.Update;

        }

        public clsPerson()
        {
            Id = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Email = "";
            Phone = "";
            DateOfBirth = DateTime.Now;
            Country = "";
            Address = "";
            ImagePath = "";
            NationalNO = "";
            Gender = "";
            Mode = enMode.Add;
        }


        public static bool DeletePerson(int id)
        {
            return clsPersonData.DeletePerson(id);
        }

        public static bool IsPersonConnected(int id)
        {
            return clsPersonData.IsPersonWithData(id);
        }

        public static bool IsUser(int id)
        {
            return clsPersonData.IsUser(id);
        }

        public static bool IsUser(string nationalno)
        {
            return clsPersonData.IsUser(nationalno);
        }

        public static int GenderNameToNum(string name)
        {
            switch(name)
            {
                case "Male":
                    return 0;
                case "Female":
                    return 1;
                default:
                    return -1;
            }
        }

        public static string GenderNumToName(int gender)
        {
            switch (gender)
            {
                case 0:
                    return "Male";
                case 1:
                    return "Female";
                default:
                    return "Unknown";
            }
        }

        private bool _AddPerson()
        {
            this.Id = clsPersonData.AddPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.NationalNO, this.Phone, this.Email, this.Address, clsCountryData.FindIDByName(this.Country), this.ImagePath, this.DateOfBirth, GenderNameToNum(this.Gender));
            return (this.Id != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.Id,this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.NationalNO, this.Phone, this.Email, this.Address, clsCountryData.FindIDByName(this.Country), this.ImagePath, this.DateOfBirth, GenderNameToNum(this.Gender));
            
        }

        public bool Save()
        {
            if(this.Mode == enMode.Add)
            {
                if(this._AddPerson())
                {
                    this.Mode = enMode.Update;
                    return true;
                }
              
            }
            else if(this.Mode == enMode.Update)
            {
                if(this._UpdatePerson())
                {
                    return true;
                }
            }
            return false;
        }

        public static clsPerson Find(int id)
        {
           string FirstName = "";
           string SecondName = "";
           string ThirdName = "";
           string LastName = "";
           string Email = "";
           string Phone = "";
           DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
          string  Address = "";
            string ImagePath = "";
           string NationalNO = "";
            int Gender = -1;
            if(clsPersonData.Find(id,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref NationalNO,ref Phone,ref Email
,            ref Address,ref CountryID,ref ImagePath,ref DateOfBirth,ref Gender))
            {
                return new clsPerson(id, FirstName, SecondName, ThirdName, LastName, NationalNO, Phone, Email,Address,clsCountryData.FindNameByID(CountryID), ImagePath, DateOfBirth,
                   GenderNumToName(Gender));
            }
            return null;
        }

        public static clsPerson Find(string nationalno)
        {
            int id = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            string Address = "";
            string ImagePath = "";
           
            int Gender = -1;
            if (clsPersonData.Find(ref id, ref FirstName, ref SecondName, ref ThirdName, ref LastName, nationalno, ref Phone, ref Email
, ref Address, ref CountryID, ref ImagePath, ref DateOfBirth, ref Gender))
            {
                return new clsPerson(id, FirstName, SecondName, ThirdName, LastName, nationalno, Phone, Email, Address, clsCountryData.FindNameByID(CountryID), ImagePath, DateOfBirth,
                   GenderNumToName(Gender));
            }
            return null;
        }

        public static bool PersonExist(int id)
        {
            return Find(id) != null;
        }

        public static bool PersonExist(string nationalno)
        {
            return Find(nationalno) != null;
        }

        public static DataTable GetPersonList(string where, string order)
        {
            return clsPersonData.GetPersonList(where, order);
        }

        public static DataTable GetPersonColumns()
        {
            return clsPersonData.GetPersonColumns();
        }


        public static bool HasLicense(string license, int personid)
        {
            return clsPersonData.HasLicense(personid,clsLicenseClass.Find(license).id);
        }

        public static int HasSameApplication(string license, int personid)
        {
            return clsPersonData.HasSameApplication(personid,clsLicenseClass.Find(license).id);
        }
    }
}

