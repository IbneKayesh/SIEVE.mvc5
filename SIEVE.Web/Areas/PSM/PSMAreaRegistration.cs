using System.Web.Mvc;

namespace SIEVE.Web.Areas.PSM
{
    public class PSMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PSM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PSM_default",
                "PSM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}