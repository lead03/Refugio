﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Business
{
    public class Veterinarian
    {
        public static List<DTO.Veterinarian> GetVeterinariansFilteredAndPaged(int currentPage, int pageSize, string keyword = null)
        {
            List<DTO.Veterinarian> veterinarians = DataAccess.Veterinarian.GetAllPaged(currentPage, pageSize, keyword);
            return veterinarians;//asd
        }

        public static int GetTotalPages(int pageSize, int totalElements)
        {
            int totalPages = (int)Math.Ceiling((double)totalElements / pageSize);
            return totalPages;
        }

        public static object GetVeterinarianById(int id)
        {
            DTO.Veterinarian veterinarian = DataAccess.Generic.GetByIdIntType<DTO.Veterinarian>(id);
            return veterinarian;
        }

        public static int GetAllCount()
        {
            int total = DataAccess.Generic.GetFilteredCount<DTO.Veterinarian>();
            return total;
        }
    }
}
