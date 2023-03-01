using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Edit
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string PhoneNumberMain { get; set; }
        public string PhoneNumberAditional { get; set; }
        public int Speciality { get; set; }
        public bool IsPermanent { get; set; }
        public decimal? Salary { get; set; }
        public int? TimeSlot { get; set; }
        public string ProfessionalLicense { get; set; }
        public string Description { get; set; }

        public void GetValues(DTO.Veterinarian veterinarian)
        {
            this.Id = veterinarian.Id;
            this.UserName = veterinarian.UserName;
            this.UserPassword = veterinarian.UserPassword;
            this.FirstName = veterinarian.FirstName;
            this.LastName = veterinarian.LastName;
            this.StreetAddress = veterinarian.StreetAddress;
            this.ApartmentNumber = veterinarian.ApartmentNumber;
            this.City = veterinarian.City;
            this.ZipCode = veterinarian.ZipCode;
            this.Province = veterinarian.Province;
            this.PhoneNumberMain = veterinarian.PhoneNumberMain;
            this.PhoneNumberAditional = veterinarian.PhoneNumberAditional;
            this.Speciality = veterinarian.Speciality;
            this.IsPermanent = veterinarian.IsPermanent;
            this.Salary = veterinarian.Salary;
            this.TimeSlot = veterinarian.TimeSlot;
            this.ProfessionalLicense = veterinarian.ProfessionalLicense;
            this.Description = veterinarian.ForDescription;
        }

        public void SetValues(DTO.Veterinarian veterinarian)
        {
            veterinarian.Id = this.Id;
            veterinarian.UserName = this.UserName;
            veterinarian.UserPassword = this.UserPassword;
            veterinarian.FirstName = this.FirstName;
            veterinarian.LastName = this.LastName;
            veterinarian.StreetAddress = this.StreetAddress;
            veterinarian.ApartmentNumber = this.ApartmentNumber;
            veterinarian.City = this.City;
            veterinarian.ZipCode = this.ZipCode;
            veterinarian.Province = this.Province;
            veterinarian.PhoneNumberMain = this.PhoneNumberMain;
            veterinarian.PhoneNumberAditional = this.PhoneNumberAditional;
            veterinarian.Speciality = this.Speciality;
            veterinarian.IsPermanent = this.IsPermanent;
            veterinarian.Salary = this.Salary;
            veterinarian.TimeSlot = this.TimeSlot;
            veterinarian.ProfessionalLicense = this.ProfessionalLicense;
            veterinarian.ForDescription = this.Description;
        }
    }
}
