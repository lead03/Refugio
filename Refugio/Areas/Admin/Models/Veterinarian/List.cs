using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class List
    {
        public List<DTO.Veterinarian> Veterinarians { get; set; }
        public Refugio.Models.Shared.Pager Pager { get; set; } = new Refugio.Models.Shared.Pager();
        public Refugio.Areas.Admin.Models.Veterinarian.Filter Filters { get; set; }
    }
}