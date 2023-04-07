using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Details
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PhoneNumberMain { get; set; }
        public string PhoneNumberAditional { get; set; }
        public int Speciality { get; set; }
        public string SpecialityName { get; set; }
        public bool IsPermanent { get; set; }
        public decimal? Salary { get; set; }
        public string TimeSlot { get; set; }
        public string ProfessionalLicense { get; set; }
        public string Description { get; set; }
        public void GetValues(DTO.Veterinarian veterinarian)
        {
            this.Id = veterinarian.Id;
            this.UserName = veterinarian.UserName;
            this.FirstName = veterinarian.FirstName;
            this.LastName = veterinarian.LastName;
            this.StreetAddress = veterinarian.StreetAddress;
            this.ApartmentNumber = veterinarian.ApartmentNumber;
            this.City = veterinarian.City;
            this.ZipCode = veterinarian.ZipCode;
            this.Province = veterinarian.Province;
            this.PhoneNumberMain = veterinarian.PhoneNumberMain;
            this.PhoneNumberAditional = veterinarian.PhoneNumberAditional;
            this.SpecialityName = veterinarian.VeterinarianSpeciality.SpecialityName;
            this.IsPermanent = veterinarian.IsPermanent;
            this.Salary = veterinarian.Salary;
            this.TimeSlot = veterinarian.TimeSlotRange.TimeRange;
            this.ProfessionalLicense = veterinarian.ProfessionalLicense;
            this.Description = veterinarian.ForDescription;
        }
    }
}