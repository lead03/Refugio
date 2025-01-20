using Refugio.Resources.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Edit
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MinLength(4, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinNumberOfCharacters4")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters50")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters100")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters100")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters50")]
        public string StreetAddress { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters50")]
        public string ApartmentNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters50")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters50")]
        public string Province { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters10")]
        public string ZipCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters15")]
        public string PhoneNumberMain { get; set; }

        [MaxLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters15")]
        public string PhoneNumberAditional { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public int Speciality { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public bool IsPermanent { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999999999999999, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "FieldDecimalBetween")]
        public decimal? Salary { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999999999999999, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "FieldDecimalBetween")]
        public decimal? Fee { get; set; }

        public int? TimeSlot { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [MaxLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxNumberOfCharacters10")]
        public string ProfessionalLicense { get; set; }

        public string DescriptionEN { get; set; }

        public string DescriptionES { get; set; }

        public string Email { get; set; }

        public bool InLanding { get; set; }

        public Guid? ProfileImageId { get; set; }

        public SelectList VeterinarianSpecialityList { get; set; }

        public SelectList TimeSlotRangeList { get; set; }

        public byte[] RowVersion { get; set; }

        public string DocNumber { get; set; }

        public string CUIT { get; set; }

        public bool IsNew
        {
            get
            {
                return this.Id == 0;
            }
        }
    }
}
