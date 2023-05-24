using System.Web.Mvc;

namespace SIEVE.Web.Areas.AA
{
    public class AAAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AA";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AA_default",
                "AA/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}