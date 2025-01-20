using Refugio.Resources.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.VeterinarianSpeciality
{
    public class Edit
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_SpecialityNameES", ResourceType = typeof(Global))]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string SpecialityNameES { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "RequieredField")]
        [Display(Name = "FieldName_SpecialityNameEN", ResourceType = typeof(Global))]
        [StringLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLengthExceeded")]
        public string SpecialityNameEN { get; set; }

        [Display(Name = "FieldName_ProfessionalsAssociatedCount", ResourceType = typeof(Global))]
        public int ProfessionalsAssociatedCount {  get; set; }

        public byte[] RowVersion { get; set; }
        
        public bool IsNew
        {
            get
            {
                return this.Id == 0;
            }
        }
    }
}