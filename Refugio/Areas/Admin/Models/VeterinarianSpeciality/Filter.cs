﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Areas.Admin.Models.VeterinarianSpeciality
{
    public class Filter
    {
        public string Keyword { get; set; }
        public bool FilterModified { get; set; } = false;
    }
}