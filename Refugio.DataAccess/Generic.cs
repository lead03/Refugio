using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DataAccess
{
    public class Generic
    {
        public static T GetById<T>(object id) where T : class
        {
            bool idIsIntType = int.TryParse(id.ToString(), out int intId);
            bool idIsGuidType = Guid.TryParse(id.ToString(), out Guid guidId);
            return idIsIntType ? DataAccess.Generic.GetByIdIntType<T>(intId)
                 : idIsGuidType ? DataAccess.Generic.GetByIdGuidType<T>(guidId)
                 : throw new Exception("Bad Id");
        }

        private static T GetByIdIntType<T>(int id) where T : class
        {
            return Common.DataContext.Set<T>().Find(id);
        }

        private static T GetByIdGuidType<T>(Guid id) where T : class
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

        public static void Delete<T>(T entity) where T : class
        {
            Common.DataContext.Set<T>().Remove(entity);
        }
    }
}
