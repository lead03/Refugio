using System;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Details
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
        public decimal? Fee { get; set; }
        public string TimeSlot { get; set; }
        public string ProfessionalLicense { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionES { get; set; }
        public bool InLanding { get; set; }
        public Guid? ProfileImageId { get; set; }

        public void GetValues(DTO.Veterinarian veterinarian)
        {
            var language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
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
            this.SpecialityName = veterinarian.VeterinarianSpeciality.SpecialityNameEN;
            this.IsPermanent = veterinarian.IsPermanent;
            this.Salary = veterinarian.Salary;
            this.TimeSlot = veterinarian.TimeSlotRange.TimeRange;
            this.ProfessionalLicense = veterinarian.ProfessionalLicense;
            this.DescriptionEN = veterinarian.DescriptionEN;
            this.DescriptionES = veterinarian.DescriptionEN;
            switch (language)
            {
                case Refugio.Resources.Language.EnglishKey:
                    this.SpecialityName = veterinarian.VeterinarianSpeciality.SpecialityNameEN;
                    break;
                case Refugio.Resources.Language.SpanishKey:
                    this.SpecialityName = veterinarian.VeterinarianSpeciality.SpecialityNameES;
                    break;
            }
        }
    }
}