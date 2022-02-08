using System.Web.Mvc;

namespace BSAF16072021.Areas.users
{
    public class usersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "users_default",
                "users/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "BSAF16072021.Areas.Users.Controllers" }
            );
        }
    }
}