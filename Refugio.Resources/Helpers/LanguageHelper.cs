using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Refugio.Resources.Helpers
{
    public static class LanguageHelper
    {
        public static string GetLanguageKey()
        {
            try
            {
                HttpCookie languageCookie = HttpContext.Current.Request.Cookies["Language"];
                if (languageCookie == null)
                {
                    throw new Exception(Resources.Languages.Global.LanguageCookieNotFound);
                }
                return languageCookie.Value;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return Resources.Language.DefaultLanguage;
            }
        }

        private static void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
        }
    }

}
