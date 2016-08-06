using System.Reflection;
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

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(this.CreateKernel);
            var webApiConfig = new HttpConfiguration();
            webApiConfig.MapHttpAttributeRoutes();
            webApiConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            webApiConfig.EnableCors();
            webApiConfig.Formatters
              .JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            app.UseNinjectWebApi(webApiConfig);
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

        }
    }
}
