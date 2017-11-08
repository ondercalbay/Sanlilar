using System.Web;
using System.Web.Mvc;

namespace Sanlilar.WebUITermalOtel
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
