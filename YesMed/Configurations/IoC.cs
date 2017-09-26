using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YesMed.Configurations
{
    public static class IoC
    {
        private static IContainer _container;

         public static void Initializewith(IContainer container)
        {
            _container = container;
        }

        public static TType Resovle<TType>()
        {
            return _container.Resolve<TType>();
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
        public static TType Resovle<TType>(string name)
        {
            return _container.ResolveNamed<TType>(name);
        }
        public static IList<TType> ResolveAll<TType>()
        {
            return (IList<TType>)_container.Resolve<IEnumerable<TType>>();
        }
    }
}