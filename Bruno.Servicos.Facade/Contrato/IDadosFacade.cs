using Bruno.Servicos.DTO;
using System.Collections.Generic;

namespace Bruno.Servicos.Facade.Contrato
{
    public interface IDadosFacade
    {
        IList<DadosUsuarioDTO> BuscarLista();
        IList<DadosUsuarioDTO> BuscarPorId(long id);
        IList<DadosUsuarioDTO> BuscarPorNome(string Nome);
        IList<DadosUsuarioDTO> BuscarPorCPF(long CPF);
        void Excluir(long id);
        void Atualizar(DadosUsuarioDTO filtro);
        void Cadastrar(DadosUsuarioDTO filtro);
    }
}
