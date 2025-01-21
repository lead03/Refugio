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
        [MinLength(6, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinLengthNotMet")]
        [StringLength(30, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string StreetAddress { get; set; }

        [StringLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string ApartmentNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]    
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string Province { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string ZipCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string PhoneNumberMain { get; set; }

        [StringLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string PhoneNumberAditional { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public int SpecialityId { get; set; }

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
        [StringLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string ProfessionalLicense { get; set; }

        public string DescriptionEN { get; set; }

        public string DescriptionES { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public bool InLanding { get; set; }

        public Guid? ProfileImageId { get; set; }

        public SelectList VeterinarianSpecialityList { get; set; }

        public SelectList TimeSlotRangeList { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
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
