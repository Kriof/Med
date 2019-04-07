using System.Web.Http;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using RestServices.Models.Interfaces;
using RestServices.Services;

namespace RestServices.App_Start
{
    public class Bootstrapper
    {
        public static void Initialize(WindsorContainer container)
        {
         
            container.Install(FromAssembly.This());
            container.Register(Classes
                .FromThisAssembly()
                .BasedOn<IHttpController>()
                .ConfigureFor<ApiController>(c => c.Properties(pi => false))
                .LifestyleTransient());

            container.Register(Castle.MicroKernel.Registration.Component.For<ITagReaderService>()
                .ImplementedBy(typeof(TagReaderService)));

        }
        
    }
}
