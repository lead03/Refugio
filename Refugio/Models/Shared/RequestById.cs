using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Models.Shared
{
    public class RequestById
    {
        public int? Id { get; set; }
        public Refugio.Models.Shared.Message Message { get; set; }
    }
}


//public RequestById(int id, Refugio.Models.Shared.Message message)
//{
//    this.Id = id;
//    this.Message = message;
//}