﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult ChangeLanguage(string language, string returnUrl)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            HttpCookie cookie = new HttpCookie("Language", language);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}
