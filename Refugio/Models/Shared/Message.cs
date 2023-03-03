using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Models.Shared
{
    public class Message
    {
        public bool ShowMessage { get; set; }
        public string MessageToShow { get; set; }
        public int TypeMessage { get; set; }

        public Message(TempDataDictionary tempData)
        {
            this.ShowMessage = tempData["ShowMessage"] != null ? (bool)tempData["ShowMessage"] : false;
            this.MessageToShow = tempData["MessageToShow"] != null ? (string)tempData["MessageToShow"] : "No hay detalles del alerta";
            this.TypeMessage = tempData["TypeMessage"] != null ? (int)tempData["TypeMessage"] : (int)Business.Common.AlertMessageType.Default;
        }
    }
}