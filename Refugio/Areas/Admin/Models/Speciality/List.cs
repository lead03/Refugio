using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.Speciality
{
    public class List
    {
        public List<DTO.vw_VeterinarianSpecialities> Specialities { get; set; }
        public Refugio.Models.Shared.Pager Pager { get; set; } = new Refugio.Models.Shared.Pager();
        public Refugio.Areas.Admin.Models.Veterinarian.Filter Filters { get; set; } = new Refugio.Areas.Admin.Models.Veterinarian.Filter();
    }
}