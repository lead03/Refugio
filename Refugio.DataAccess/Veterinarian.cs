using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DataAccess
{
    public class Veterinarian
    {
        public static List<DTO.Veterinarian> GetAllPaged(int currentPage, int pageSize, string keyword = null)
        {
            IQueryable<DTO.Veterinarian> query = Common.DataContext.Veterinarian;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.LastName.Contains(keyword) || x.FirstName.Contains(keyword) || x.ForDescription.Contains(keyword));
            }
            query = query.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);
            return query.ToList();
        }

        public static int GetCount(string keyword = null)
        {
            IQueryable<DTO.Veterinarian> query = Common.DataContext.Veterinarian;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.LastName.Contains(keyword) || x.FirstName.Contains(keyword) || x.ForDescription.Contains(keyword));
            }
            return query.Count();
        }
    }
}
