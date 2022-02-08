using System.Web.Mvc;

namespace BSAF16072021.Areas.training
{
    public class trainingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "training";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "training_default",
                "training/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "BSAF16072021.Areas.Training.Controllers" }
            );
        }
    }
}