using Bruno.Servicos.Dominio.Repositorio;
using Bruno.Servicos.DTO;
using Bruno.Servicos.Facade.Contrato;
using Bruno.Servicos.Utilitario;
using AutoMapper;
using System.Collections.Generic;
using Bruno.Servicos.Dominio.Entidades;
using System;

namespace Bruno.Servicos.Facade
{
    public class DadosFacade : IDadosFacade
    {      
        public IList<DadosUsuarioDTO> BuscarPorCPF(long CPF)
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();
            var requisicao = repositorio.BuscarPorCPF(CPF);

            return Mapper.Map<IList<DadosUsuario>, IList<DadosUsuarioDTO>>(requisicao);
        }
        public IList<DadosUsuarioDTO> BuscarPorId(long id)
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();
            var requisicao = repositorio.BuscarPorId(id);

            return Mapper.Map<IList<DadosUsuario>, IList<DadosUsuarioDTO>>(requisicao);
        }     
        public IList<DadosUsuarioDTO> BuscarPorNome(string Nome)
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();
            var requisicao = repositorio.BuscarPorNome(Nome);

            return Mapper.Map<IList<DadosUsuario>, IList<DadosUsuarioDTO>>(requisicao);
        }
        public void Atualizar(DadosUsuarioDTO filtro)
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();
            var dados = Mapper.Map<DadosUsuarioDTO, DadosUsuario>(filtro);

            repositorio.Atualizar(dados);
        }
        public void Cadastrar(DadosUsuarioDTO filtro)
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();
            var dados = Mapper.Map<DadosUsuarioDTO, DadosUsuario>(filtro);

            repositorio.Cadastrar(dados);
        }
        public void Excluir(long id)
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();          

            repositorio.Excluir(id);
        }

        public IList<DadosUsuarioDTO> BuscarLista()
        {
            var repositorio = DependencyFactory.Resolve<IDadosUsuarioRepositorio>();
            var requisicao = repositorio.BuscarLista();

            return Mapper.Map<IList<DadosUsuario>, IList<DadosUsuarioDTO>>(requisicao);
        }
    }
}
