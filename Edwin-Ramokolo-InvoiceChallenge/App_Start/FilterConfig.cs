using System.Web;
using System.Web.Mvc;

namespace Edwin_Ramokolo_InvoiceChallenge
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
