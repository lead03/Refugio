﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Refugio.Business
{
    public class VeterinarianSpeciality
    {
        public static List<DTO.vw_VeterinarianSpecialities> GetVeterinarianSpecialitiesFilteredAndPaged(int currentPage, int pageSize, string keyword = null)
        {
            string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            List<DTO.vw_VeterinarianSpecialities> specialities = DataAccess.VeterinarianSpeciality.GetFilteredPaged(currentPage, pageSize, keyword, language).ToList();
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
            return DataAccess.VeterinarianSpeciality.GetCount(keyword, language);
        }

        public static DTO.VeterinarianSpeciality GetById(int id)
        {
            return DataAccess.Generic.GetById<DTO.VeterinarianSpeciality>(id);
        }

        public static int GetVeterinarianCountBySpecialityId(int id)
        {
            return DataAccess.Veterinarian.GetByVeterinarianSpeciality(id);
        }

        public static int Save(DTO.VeterinarianSpeciality veterinarianSpeciality)
        {
            try
            {
                DataAccess.Generic.UpdateOrCreate<DTO.VeterinarianSpeciality>(veterinarianSpeciality, veterinarianSpeciality.Id);
                return veterinarianSpeciality.Id;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }
    }
}
