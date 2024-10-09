using System.Web;
using System.Web.Mvc;
using ToDoListMvcAsp.Services;


namespace ToDoListMvcAsp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        
    }
}
