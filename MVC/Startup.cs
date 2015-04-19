using Autofac;
using Autofac.Integration.Mvc;
using Entities.Models;
using Infrastructure;
using Microsoft.Owin;
using Owin;
using Services.Accounts;
using Services.Categories;
using Services.Products;
using Services.Suppliers;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(MVC.Startup))]

namespace MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuthentication(app);

            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AccountsService>().As<IAccountsService>();
            builder.RegisterType<ProductsService>().As<IProductsService>();
            builder.RegisterType<CategoriesService>().As<ICategoriesService>();
            builder.RegisterType<SuppliersService>().As<ISuppliersService>();
            
            builder.RegisterType(typeof(NorthContext)).As(typeof(INorthContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UowData)).As(typeof(IUowData)); 

            // Run other optional steps, like registering model binders,
            // web abstractions, etc., then set the dependency resolver
            // to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // OWIN MVC SETUP:

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}