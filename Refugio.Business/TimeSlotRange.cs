using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Business
{
    public class TimeSlotRange
    {
        public static List<DTO.TimeSlotRange> GetAll()
        {
            List<DTO.TimeSlotRange> list = DataAccess.Generic.GetAll<DTO.TimeSlotRange>().OrderBy(x => x.TimeRange).ToList();
            return list;
        }
    }
}
