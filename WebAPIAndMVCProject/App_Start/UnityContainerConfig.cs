using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebAPIAndMVCProject.DatataAccess;

namespace WebAPIAndMVCProject.App_Start
{
    public static class UnityContainerConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
           
            container.RegisterType<IWatherdataAccessLayer, WatherDataAccess>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}