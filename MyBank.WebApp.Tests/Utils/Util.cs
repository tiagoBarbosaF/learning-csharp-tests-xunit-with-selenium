using System.IO;
using System.Reflection;

namespace MyBank.WebApp.Tests.Utils
{
    public static class Util
    {
        public static string PathDriverFirefox() =>
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + $"\\Debug\\net5.0");
    }
}