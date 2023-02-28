using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Models.Shared
{
    public class Pager
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        public int PrevPageButtonsToShow { get; set; } = 2;
        public int NextPageButtonsToShow { get; set; } = 2;
        public bool ShowFirstPageButton
        {
            get
            {
                return this.CurrentPage - this.PrevPageButtonsToShow > 1;
            }
        }
        public bool ShowLastPageButton
        {
            get
            {
                return this.CurrentPage + this.NextPageButtonsToShow < this.TotalPages;
            }
        }
    }
}