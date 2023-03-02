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
        public static List<DTO.VeterinarianSpeciality> GetAll()
        {
            List<DTO.VeterinarianSpeciality> veterinarianSpecialities = DataAccess.Generic.GetAll<DTO.VeterinarianSpeciality>().OrderBy(x => x.SpecialityName).ToList();
            return veterinarianSpecialities;
        }
    }
}
