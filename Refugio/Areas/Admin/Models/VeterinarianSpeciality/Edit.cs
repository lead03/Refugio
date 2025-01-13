using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.VeterinarianSpeciality
{
    public class Edit
    {
        public int Id { get; set; }

        public string SpecialityNameES { get; set; }

        public string SpecialityNameEN { get; set; }

        public int ProfessionalsAssociated {  get; set; }

        public byte[] RowVersion { get; set; }
        
        public bool IsNewSpeciality
        {
            get
            {
                return this.Id == 0;
            }
        }
    }
}