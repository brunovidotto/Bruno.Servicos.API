using Bruno.Servicos.Dominio.Entidades;
using System.Collections.Generic;

namespace Bruno.Servicos.Dominio.Repositorio
{
    public interface IDadosUsuarioRepositorio
    {
        IList<DadosUsuario> BuscarPorId(long id);
        IList<DadosUsuario> BuscarPorNome(string Nome);
        IList<DadosUsuario> BuscarPorCPF(long CPF);
        IList<DadosUsuario> BuscarLista();
        void Excluir(long id);
        void Atualizar(DadosUsuario filtro);
        void Cadastrar(DadosUsuario filtro);
    }
}
