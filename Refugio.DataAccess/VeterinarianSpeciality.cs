using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DataAccess
{
    public class VeterinarianSpeciality
    {
        public static IQueryable<DTO.vw_VeterinarianSpecialities> GetFilteredPaged(int currentPage, int pageSize, string keyword, string language)
        {
            IQueryable<DTO.vw_VeterinarianSpecialities> query = GetFiltered(keyword, language);
            switch (language)
            {
                default:
                case Refugio.DataAccess.Classes.Language.SpanishKey:
                    query = query.OrderBy(x => x.SpecialityNameES);
                    break;
                case Refugio.DataAccess.Classes.Language.EnglishKey:
                    query = query.OrderBy(x => x.SpecialityNameEN);
                    break;
            }
            query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);
            return query;
        }

        public static IQueryable <DTO.vw_VeterinarianSpecialities> GetFiltered(string keyword, string language)
        {
            IQueryable<DTO.vw_VeterinarianSpecialities> query = Common.DataContext.vw_VeterinarianSpecialities;
            if(!string.IsNullOrEmpty(keyword))
            {
                switch (language)
                {
                    case Refugio.DataAccess.Classes.Language.SpanishKey:
                        query = query.Where(x => x.SpecialityNameES.Contains(keyword));
                        break;
                    case Refugio.DataAccess.Classes.Language.EnglishKey:
                        query = query.Where(x => x.SpecialityNameEN.Contains(keyword));
                        break;
                }
            }
            return query;
        }

        public static IQueryable GetAllOrderedByLanguage(string language = null)
        {
            IQueryable<DTO.VeterinarianSpeciality> query = Common.DataContext.VeterinarianSpeciality;
            query = DataAccess.Generic.GetAll<DTO.VeterinarianSpeciality>();
            if (!string.IsNullOrEmpty(language))
            {
                switch (language)
                {
                    default:
                    case Refugio.DataAccess.Classes.Language.SpanishKey:
                        query = query.OrderBy(x => x.SpecialityNameES);
                        break;
                    case Refugio.DataAccess.Classes.Language.EnglishKey:
                        query = query.OrderBy(x => x.SpecialityNameEN);
                        break;
                }
            }
            return query;
        }

        public static int GetCount(string keyword = null, string language = null)
        {
            IQueryable<DTO.vw_VeterinarianSpecialities> query = GetFiltered(keyword, language);
            return query.Count();
        }
    }
}
