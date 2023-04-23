using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Business
{
    public class Common
    {
        public static void CheckRowVersion(byte[] modelVersion, byte[] DTOVersion)
        {
            if(!modelVersion.SequenceEqual(DTOVersion))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
