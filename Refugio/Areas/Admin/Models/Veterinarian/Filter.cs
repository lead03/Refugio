using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Filter
    {
        public string Keyword { get; set; }
        public int Speciality { get; set; }
        public bool IsPermanent { get; set; }
        public decimal Salary { get; set; }
        public int TimeSlot { get; set; }
    }
}