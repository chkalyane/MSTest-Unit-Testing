using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using YesMed.API;
using YesMed.Data.Contexts;
using YesMed.Services;

namespace YesMed.Configurations
{
    public static class AutofacConfiguration
    {

        public static void RegisterAllInterfaces<TType>(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            var interfaceType = typeof(TType);
            builder.RegisterAssemblyTypes(assemblies).
                Where(interfaceType.IsAssignableFrom)
                .As<TType>()
                .PropertiesAutowired();
        }
        public static void Load()
        {
            FilterProviders.Providers.Clear();
            Initialize();
            ConfigureElements();
        }

        private static void ConfigureElements()
        {
            foreach (var c in IoC.ResolveAll<IElementConfiguration>())
            {
                c.Configure();
            }
        }
        private static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<YesMedEntityContext>().As<IEntityContext>().InstancePerRequest();

            builder.RegisterType<YesMedEntityContext>().Named<IEntityContext>("perDependency").InstancePerDependency().PreserveExistingDefaults();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            #region API Controllers
            builder.RegisterApiControllers(typeof(UserController).Assembly);
            builder.RegisterApiControllers(typeof(ProductController).Assembly);
            builder.RegisterApiControllers(typeof(CategoryController).Assembly);
            builder.RegisterApiControllers(typeof(OrderController).Assembly);
            builder.RegisterApiControllers(typeof(AdminUserController).Assembly);
            #endregion

            var container = builder.Build();
           
            IoC.Initializewith(container);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
         
            FilterProviders.Providers.Clear();
            FilterProviders.Providers.Add(new AutofacFilterProvider());
        }
    }
}
