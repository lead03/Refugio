using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Resources
{
    public class Common
    {
        public const string DefaultPassword = "Refugio1234";
    }
    public class Language
    {
        public const string SpanishKey = "es-ES";
        public const string EnglishKey = "en-US";
    }

    public class AlertMessage
    {
        public enum Type
        {
            Default = 0,
            Error = 1,
            Warning = 2,
            Success = 3,
        }
    }

    public class CustomModalTypes
    {
        public const string DangerKey = "danger";
        public const string SuccessKey = "success";
        public const string WarningKey = "warning";
        public const string InfoKey = "info";
    }
}
