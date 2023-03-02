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

        public static void UpdateOrCreate<T>(T entity, int id) where T : class
        {
            var entityToUpdate = Common.DataContext.Set<T>().Find(id);
            if (entityToUpdate == null)
            {
                Common.DataContext.Set<T>().Add(entity);
            }
            else
            {
                Common.DataContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            }
            Common.DataContext.SaveChanges();
        }

        public static void UpdateOrCreate<T>(T entity, Guid id) where T : class
        {
            var entityToUpdate = Common.DataContext.Set<T>().Find(id);
            if (entityToUpdate == null)
            {
                Common.DataContext.Set<T>().Add(entity);
            }
            else
            {
                Common.DataContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            }
            Common.DataContext.SaveChanges();
        }

        public static List<T> GetAll<T>() where T: class
        {
            return Common.DataContext.Set<T>().ToList();
        }
    }
}
