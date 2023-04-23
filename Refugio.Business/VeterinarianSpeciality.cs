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
        public static SelectList GetSelectListForVeterinarianSpeciality()
        {
            var language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            string propName = string.Empty;
            switch (language)
            {
                case Refugio.Resources.Language.SpanishKey:
                    propName = "SpecialityNameES";
                    break;
                case Refugio.Resources.Language.EnglishKey:
                    propName = "SpecialityNameEN";
                    break;
            }
            SelectList response = new SelectList(DataAccess.Generic.GetAll<DTO.VeterinarianSpeciality>().OrderBy(x => typeof(DTO.VeterinarianSpeciality).GetProperty(propName)).ToList(), "Id", propName);
            return response;
        }
    }
}
