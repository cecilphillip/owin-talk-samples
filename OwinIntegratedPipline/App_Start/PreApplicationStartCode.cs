using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using OwinIntegratedPipline.App_Start;


[assembly: PreApplicationStartMethod(typeof(PreApplicationStartCode), "Start")]

namespace OwinIntegratedPipline.App_Start
{
    public class PreApplicationStartCode
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(CustomModule));
        }
    }
}