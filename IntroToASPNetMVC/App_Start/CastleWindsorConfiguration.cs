using System;
using System.Diagnostics;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain;
using Domain.People;
using Improving.MediatR;

namespace IntroToASPNetMVC
{
    public class CastleWindsorConfig
    {
        public static ILogger RegisterCastleWindsor()
        {
            var container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<IHttpController>()
                    .WithServiceSelf()
                    .LifestyleScoped(typeof(WebRequestScopeAccessor)),
                Classes.FromThisAssembly()
                    .BasedOn<IController>()
                    .WithServiceSelf()
                    .LifestyleScoped(typeof(WebRequestScopeAccessor))
            );
            container.Install(new MediatRInstaller(
                Classes.FromThisAssembly(),
                Classes.FromAssemblyContaining<Person>()),
                new DomainInstaller());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(container.Kernel));

            return container.Resolve<ILogger>();
        }
    }

    class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        [DebuggerStepThrough]
        protected override IController GetControllerInstance(
            RequestContext requestContext,
            Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format(
                    "The controller for path '{0}' could not be found.",
                    requestContext.HttpContext.Request.Path));
            }
            return (IController)_kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }
    }

    class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IKernel _kernel;

        public WindsorHttpControllerActivator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return (IHttpController)_kernel.Resolve(controllerType);
        }
    }
}