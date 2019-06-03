using System.Collections.Generic;
using Unity;
using Unity.Injection;
using Unity.Registration;
using Unity.Resolution;

namespace Bruno.Servicos.Utilitario
{
    public abstract class DependencyFactory
    {
        public static IUnityContainer Container { get; private set; }

        static DependencyFactory()
        {
            var container = new UnityContainer();

            Container = container;
        }

        public static IUnityContainer RegisterInstance<T>(T param)
        {
            return Container.RegisterInstance(param);
        }
       
        public static IUnityContainer RegisterType<TContract, TConcrete>() where TConcrete : TContract
        {
            return Container.RegisterType<TContract, TConcrete>();
        }


        public static IUnityContainer RegisterType<TContract, TConcrete>(params InjectionMember[] injectionMembers) where TConcrete : TContract
        {
            return Container.RegisterType<TContract, TConcrete>(injectionMembers);
        }

        public static IUnityContainer RegisterType<TContract, TConcrete>(string name) where TConcrete : TContract
        {
            return Container.RegisterType<TContract, TConcrete>(name);
        }


        public static T Resolve<T>()
        {
            T ret = default(T);
            ret = Container.Resolve<T>();

            return ret;
        }

        public static T Resolve<T>(string name)
        {
            T ret = default(T);
            ret = Container.Resolve<T>(name);

            return ret;
        }

        public static T Resolve<T>(IDictionary<string, object> arguments)
        {
            T ret = default(T);

            ParameterOverrides overrides = GetParametersOverrideFromDictionary<T>(arguments);
            ret = Container.Resolve<T>(overrides);

            return ret;
        }

        private static ParameterOverrides GetParametersOverrideFromDictionary<T>(IDictionary<string, object> arguments)
        {
            ParameterOverrides resolverOverride = new ParameterOverrides();
            foreach (string key in arguments.Keys)
            {
                resolverOverride.Add(key, arguments[key]);
            }
            return resolverOverride;
        }




    }
}
