using Bruno.Servicos.Utilitario;
using Bruno.WPF.Entidades;
using System.Collections.ObjectModel;

namespace Bruno.WPF.Servico
{
    public static class Integracao
    {
        public static string urlApi = "http://localhost:56422/api/";
        public static ObservableCollection<DadosUsuario> BuscarListaUsuarios()
        {
            var clientApi = new ClientWebApi(urlApi);
            return clientApi.Get<ObservableCollection<DadosUsuario>>("usuario/buscarlista");
        }
        public static void ExcluirUsuario(long id)
        {
            var clientApi = new ClientWebApi(urlApi);
            clientApi.Delete("usuario/excluir?id=" + id);
        }
        public static void AdicionarUsuario(DadosUsuario dados)
        {
            try
            {
                var clientApi = new ClientWebApi(urlApi);
                var data = clientApi.Post<object>("usuario/cadastrar", dados);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }          
        }
        public static void AtualizarUsuario(DadosUsuario dados)
        {
            var clientApi = new ClientWebApi(urlApi);
            var data = clientApi.Put<object>("usuario/atualizar", dados);
        }
    }
}
