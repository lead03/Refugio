using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Business
{
    public class AlertMessage
    {
        public static void Set(System.Web.Mvc.TempDataDictionary tempData, bool showMessage, string messageToShow, int typeMessage)
        {
            tempData["ShowMessage"] = showMessage;
            tempData["MessageToShow"] = messageToShow;
            tempData["TypeMessage"] = typeMessage;
        }
    }
}
