using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Refugio.Business
{
    public class VeterinarianSpeciality
    {
        public static List<DTO.VeterinarianSpeciality> GetVeterinarianSpecialitiesFilteredAndPaged(int currentPage, int pageSize, string keyword = null)
        {
            string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            List<DTO.VeterinarianSpeciality> specialities = DataAccess.VeterinarianSpeciality.GetFilteredPaged(currentPage, pageSize, keyword, language).ToList();
            return specialities;
        }

        public static SelectList GetSelectListForVeterinarianSpeciality()
        {
            string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            string languagePropName = string.Empty;
            switch (language)
            {
                case Refugio.Resources.Language.SpanishKey:
                    languagePropName = "SpecialityNameES";
                    break;
                case Refugio.Resources.Language.EnglishKey:
                    languagePropName = "SpecialityNameEN";
                    break;
            }
            SelectList response = new SelectList(DataAccess.VeterinarianSpeciality.GetAllOrderedByLanguage(language), "Id", languagePropName);
            return response;
        }

        public static int GetTotalPages(int pageSize, string keyword)
        {
            string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            int totalPages = (int)Math.Ceiling((double)GetCountFiltered(keyword, language) / pageSize);
            return totalPages;
        }

        public static int GetCountFiltered(string keyword = null, string language = null)
        {
            int total = DataAccess.VeterinarianSpeciality.GetCount(keyword, language);
            return total;
        }
    }
}
