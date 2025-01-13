using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.VeterinarianSpeciality
{
    public class Details
    {
        public int Id { get; set; }

        public string SpecialityNameEN { get; set; }

        public string SpecialityNameES { get; set; }

        public int ProfessionalsAssociatedCount { get; set; }

    }
}