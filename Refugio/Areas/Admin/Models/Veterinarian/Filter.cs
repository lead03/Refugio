using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Filter
    {
        public string Keyword { get; set; }
        public bool IsPermanent { get; set; }
        public decimal Salary { get; set; }
        public int TimeSlot { get; set; }
        public bool FilterModified { get; set; } = false;
        public SelectList VeterinarianSpeciality { get; set; }
        public int SelectedVeterinarianSpecialityId { get; set; }
    }
}