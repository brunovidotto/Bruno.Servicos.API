using Bruno.Servicos.Dominio.Repositorio;
using Bruno.Servicos.Facade;
using Bruno.Servicos.Facade.Contrato;
using Bruno.Servicos.Repositorio;
using Bruno.Servicos.Utilitario;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Http;
using Unity;

namespace Bruno.Servicos.API
{
    public class Bootstrapper
    {
        public static IUnityContainer Container;

        public static void Initialize()
        {
            Container = Container ?? BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(Container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            Container = DependencyFactory.Container;
            DependencyFactory.RegisterInstance(new DatabaseProviderFactory().CreateDefault());
            DependencyFactory.RegisterType<IDataContext, DataContext>();

            DependencyFactory.RegisterType<IDadosUsuarioRepositorio, DadosUsuarioRepositorio>();
            DependencyFactory.RegisterType<IDadosFacade, DadosFacade>();

            return Container;
        }
    }
}