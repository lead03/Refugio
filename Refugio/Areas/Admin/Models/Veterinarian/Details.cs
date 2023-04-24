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
    }
}