using System.Web;
using System.Web.Mvc;

namespace Exercise1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // ep91 Log In Required for everything
            filters.Add(new AuthorizeAttribute());
        
        }
    }
}
