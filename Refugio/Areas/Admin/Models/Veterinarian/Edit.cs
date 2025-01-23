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
        [Display(Name = "FieldName_UserName", ResourceType = typeof(Global))]
        [MinLength(6, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinLengthNotMet")]
        [StringLength(30, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_FirstName", ResourceType = typeof(Global))]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        [Display(Name = "FieldName_LastName", ResourceType = typeof(Global))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        [Display(Name = "FieldName_Address", ResourceType = typeof(Global))]
        public string StreetAddress { get; set; }

        [StringLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        [Display(Name = "FieldName_ApartmentNumber", ResourceType = typeof(Global))]
        public string ApartmentNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_City", ResourceType = typeof(Global))]
        [StringLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]    
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_State", ResourceType = typeof(Global))]
        [StringLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string Province { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_ZipCode", ResourceType = typeof(Global))]
        [StringLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string ZipCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_PhoneNumberMain", ResourceType = typeof(Global))]
        [StringLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string PhoneNumberMain { get; set; }

        [Display(Name = "FieldName_PhoneNumberAdditional", ResourceType = typeof(Global))]
        [StringLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string PhoneNumberAditional { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_SpecialityId", ResourceType = typeof(Global))]
        public int SpecialityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_IsPermanent", ResourceType = typeof(Global))]
        public bool IsPermanent { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "FieldName_Salary", ResourceType = typeof(Global))]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999999999999999, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "FieldDecimalBetween")]
        public decimal? Salary { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FieldName_Fee", ResourceType = typeof(Global))]
        [Range(0, 9999999999999999, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "FieldDecimalBetween")]
        public decimal? Fee { get; set; }

        [Display(Name = "FieldName_TimeSlotId", ResourceType = typeof(Global))]
        public int? TimeSlot { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_ProfessionalLicense", ResourceType = typeof(Global))]
        [StringLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string ProfessionalLicense { get; set; }

        [Display(Name = "FieldName_DescriptionEN", ResourceType = typeof(Global))]
        public string DescriptionEN { get; set; }

        [Display(Name = "FieldName_DescriptionES", ResourceType = typeof(Global))]
        public string DescriptionES { get; set; }

        [Display(Name = "FieldName_Email", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public string Email { get; set; }

        [Display(Name = "FieldName_Landing", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public bool InLanding { get; set; }

        public Guid? ProfileImageId { get; set; }

        public SelectList VeterinarianSpecialityList { get; set; }

        public SelectList TimeSlotRangeList { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        public byte[] RowVersion { get; set; }

        [Display(Name = "FieldName_DocNumber", ResourceType = typeof(Global))]
        public string DocNumber { get; set; }

        [Display(Name = "FieldName_CUIT", ResourceType = typeof(Global))]
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
