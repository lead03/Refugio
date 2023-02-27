using System;
using System.Web;

namespace Refugio.DataAccess
{
    public class Common
    {

        public static DTO.RefugioEntities MockDataContext { get; set; }

        public static bool IsTesting { get; set; } = false;

        public static DTO.RefugioEntities DataContext
        {
            get
            {
                if (!IsTesting)
                {
                    if (HttpContext.Current.Items["DataContext"] == null)
                    {
                        HttpContext.Current.Items["DataContext"] = new DTO.RefugioEntities();
                    }
                    return (DTO.RefugioEntities)HttpContext.Current.Items["DataContext"];
                }
                else
                {
                    return MockDataContext;
                }

            }
        }

        public static void ResetDataContext()
        {
            try
            {
                HttpContext.Current.Items["DataContext"] = null;
            }
            catch (Exception ex)
            {
                throw new Exception("ResetDataContext: " + ex.Message);
            }
        }
    }
}
