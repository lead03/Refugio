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
                throw new InvalidOperationException("Hubo modificaciones mientras usted realizaba la operación. Vuelva a cargar la página e inténtelo nuevamente.");
            }
        }

        public static string DefaultPassword { get; set; } = "Refugio1234";

        public enum AlertMessageType
        {
            Default = 0,
            Error = 1,
            Warning = 2,
            Success = 3,
        }
    }
}
