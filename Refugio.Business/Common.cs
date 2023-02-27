using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Business
{
    public class Common
    {
        public static T GetById<T>(object id) where T : class
        {
            bool idIsIntType = int.TryParse(id.ToString(), out int intId);
            bool idIsGuidType = Guid.TryParse(id.ToString(), out Guid guidId);
            return idIsIntType ? DataAccess.Generic.GetByIdIntType<T>(intId)
                 : idIsGuidType ? DataAccess.Generic.GetByIdGuidType<T>(guidId)
                 : throw new Exception("Bad Id");
        }
    }
}
