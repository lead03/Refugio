using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Controllers
{
    public class AlertMessageController : Controller
    {
        [HttpGet]
        public ActionResult GetTempData()
        {
            TempDataDictionary info = TempData;
            var tempData = new
            {
                ShowMessage = info["ShowMessage"] != null && (bool)info["ShowMessage"],
                MessageToShow = info["MessageToShow"] != null ? (string)info["MessageToShow"] : "No hay detalles del alerta",
                TypeMessage = info["TypeMessage"] != null ? (int)info["TypeMessage"] : (int)Refugio.Resources.AlertMessage.Type.Default,
            };
            return Json(tempData, JsonRequestBehavior.AllowGet);
        }
    }
}
