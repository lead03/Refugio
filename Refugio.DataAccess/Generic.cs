using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DataAccess
{
    public class Generic
    {
        public static T GetByIdIntType<T>(int id) where T : class
        {
            return Common.DataContext.Set<T>().Find(id);
        }

        public static T GetByIdGuidType<T>(Guid id) where T : class
        {
            return Common.DataContext.Set<T>().Find(id);
        }

        public static int GetCount<T>() where T : class
        {
            return Common.DataContext.Set<T>().Count();
        }
    }
}
