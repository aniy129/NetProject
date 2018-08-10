using System.Web;
using System.Web.Mvc;

namespace Csk.Development.JsValidate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
