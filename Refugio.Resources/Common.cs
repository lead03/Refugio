using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public const string SpanishAbbreviation = "ES";
        public const string EnglishKey = "en-US";
        public const string EnglishAbbreviation = "EN";
        public const string DefaultLanguage = "en";
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

    public class CustomModal
    {
        public enum Types
        {
            Danger,
            Success,
            Warning,
            Info
        }

        public enum Size
        {
            Small,
            Medium,
            Large,
        }
    }
}
