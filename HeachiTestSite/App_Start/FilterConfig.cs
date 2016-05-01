using SignU.In.MVCFilter;
using System.Web;
using System.Web.Mvc;

namespace HeachiTestSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthenticationFilter());
            filters.Add(new AuthenticationFilterDev());

            filters.Add(new HandleErrorAttribute());
        }
    }
}
