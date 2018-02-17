using System.IO;
using System.Web;

namespace Sanlilar.CommonLibrary.Helpers
{
    public class FileHelper
    {
        public static string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(MapPath(path));
        }
    }
}
