﻿using System.Reflection;
using System.Web.Http;

using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using Owin;

[assembly: OwinStartup(typeof(BookLover.Web.Startup))]

namespace BookLover.Web
{
    using System.Threading.Tasks;
    using System.Web.Cors;
    using DataAccessLayer.Contexts;
    using DataAccessLayer.Data;
    using UserSessionUtils;
    using Common.Mappings;
    using System.Collections.Generic;
    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using EntityModels;
    using Models.DataTransferObjects;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(this.CreateKernel);
            var webApiConfig = new HttpConfiguration();
            webApiConfig.MapHttpAttributeRoutes();

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<BookDto>("Odata");
            webApiConfig.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            webApiConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            webApiConfig.EnableCors();
            //webApiConfig.Formatters
            //  .JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            app.UseNinjectWebApi(webApiConfig);

            var autoMapperConfig = new AutoMapperConfig(new List<Assembly> { Assembly.GetExecutingAssembly() });
            autoMapperConfig.Execute();
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            this.RegisterMappings(kernel);

            return kernel;
        }

        private void RegisterMappings(IKernel kernel)
        {
            kernel.Bind<IBookLoverData>().To<BookLoverBookLoverData>();
            kernel.Bind<IBookLoverDbContext>().To<BookLoverDbContext>();
            kernel.Bind<IUserSessionManager>().To<UserSessionManager>();
        }
    }
}
