using System.Web;
using System.Web.Mvc;
using IntroToASPNetMVC.Filters;

namespace IntroToASPNetMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidationExceptionFilter());
        }
    }
}
