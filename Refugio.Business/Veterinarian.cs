using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Business
{
    public class Veterinarian
    {
        public static List<DTO.Veterinarian> GetVeterinariansFilteredAndPaged(int currentPage, int pageSize, string keyword = null, int selectedVeterinarianSpecialityId = 0)
        {
            List<DTO.Veterinarian> veterinarians = DataAccess.Veterinarian.GetAllPaged(currentPage, pageSize, keyword, selectedVeterinarianSpecialityId);
            return veterinarians;
        }

        public static int GetTotalPages(int pageSize)
        {
            int totalPages = (int)Math.Ceiling((double)GetAllCount() / pageSize);
            return totalPages;
        }

        public static int GetTotalPages(int pageSize, string keyword = null)
        {
            int totalPages = (int)Math.Ceiling((double)GetCountFiltered(keyword) / pageSize);
            return totalPages;
        }

        public static DTO.Veterinarian GetVeterinarianById(int id)
        {
            DTO.Veterinarian veterinarian = DataAccess.Generic.GetById<DTO.Veterinarian>(id);
            return veterinarian;
        }

        public static int GetAllCount()
        {
            int total = DataAccess.Generic.GetCount<DTO.Veterinarian>();
            return total;
        }

        public static int GetCountFiltered(string keyword = null)
        {
            int total = DataAccess.Veterinarian.GetCount(keyword);
            return total;
        }

        public static void Save (DTO.Veterinarian veterinarian)
        {
            DataAccess.Generic.UpdateOrCreate<DTO.Veterinarian>(veterinarian, veterinarian.Id);
        }
    }
}
