using Bruno.Servicos.Dominio.Entidades;
using Bruno.Servicos.Dominio.Repositorio;
using Bruno.Servicos.Utilitario.ExtensionsMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bruno.Servicos.Repositorio
{
    public class DadosUsuarioRepositorio : BaseRepositorio, IDadosUsuarioRepositorio
    {
        public DadosUsuarioRepositorio(IDataContext dataContext) : base(dataContext)
        {

        }
        public IList<DadosUsuario> BuscarPorId(long id)
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");

            DataContext.AddParameters("@Operacao", 4, DbType.String);
            DataContext.AddParameters("@Id", id, DbType.Int64);

            var lista = DataContext.ExecuteReader().ToList<DadosUsuario>().ToList();
            return lista;
        }
        public IList<DadosUsuario> BuscarPorNome(string Nome)
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");

            DataContext.AddParameters("@Operacao", 4, DbType.String);
            DataContext.AddParameters("@Nome", Nome, DbType.String);

            var lista = DataContext.ExecuteReader().ToList<DadosUsuario>().ToList();
            return lista;
        }
        public IList<DadosUsuario> BuscarPorCPF(long CPF)
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");

            DataContext.AddParameters("@Operacao", 4, DbType.String);
            DataContext.AddParameters("@CPF", CPF, DbType.Int64);

            var lista = DataContext.ExecuteReader().ToList<DadosUsuario>().ToList();
            return lista;
        }
        public void Atualizar(DadosUsuario filtro)
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");
            DataContext.AddParameters("@Operacao", 2, DbType.String);

            if (filtro.Id != 0)
                DataContext.AddParameters("@Id", filtro.Id, DbType.Int64);

            if (!String.IsNullOrEmpty(filtro.Nome))
                DataContext.AddParameters("@Nome", filtro.Nome, DbType.String);

            if (filtro.CPF != 0)
                DataContext.AddParameters("@CPF", filtro.CPF, DbType.Int64);

            if (!String.IsNullOrEmpty(filtro.Email))
                DataContext.AddParameters("@Email", filtro.Email, DbType.String);

            if (!String.IsNullOrEmpty(filtro.Telefone))
                DataContext.AddParameters("@Telefone", filtro.Telefone, DbType.String);

            if (!String.IsNullOrEmpty(filtro.Sexo))
                DataContext.AddParameters("@Sexo", filtro.Sexo, DbType.String);

            if (filtro.DataNascimento != DateTime.MinValue)
                DataContext.AddParameters("@DataNascimento", filtro.DataNascimento, DbType.Date);

            DataContext.ExecuteReader();
        }
        public void Excluir(long id)
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");
            DataContext.AddParameters("@Operacao", 3, DbType.String);

            DataContext.AddParameters("@Id", id, DbType.Int64);

            DataContext.ExecuteReader();
        }
        public void Cadastrar(DadosUsuario filtro)
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");
            DataContext.AddParameters("@Operacao", 1, DbType.String);

            if (!String.IsNullOrEmpty(filtro.Nome))
                DataContext.AddParameters("@Nome", filtro.Nome, DbType.String);

            if (filtro.CPF != 0)
                DataContext.AddParameters("@CPF", filtro.CPF, DbType.Int64);

            if (!String.IsNullOrEmpty(filtro.Email))
                DataContext.AddParameters("@Email", filtro.Email, DbType.String);

            if (!String.IsNullOrEmpty(filtro.Telefone))
                DataContext.AddParameters("@Telefone", filtro.Telefone, DbType.String);

            if (!String.IsNullOrEmpty(filtro.Sexo))
                DataContext.AddParameters("@Sexo", filtro.Sexo, DbType.String);

            if (filtro.DataNascimento != DateTime.MinValue)
                DataContext.AddParameters("@DataNascimento", filtro.DataNascimento, DbType.Date);

            DataContext.ExecuteReader();
        }

        public IList<DadosUsuario> BuscarLista()
        {
            DataContext.StartCommand(CommandType.StoredProcedure, "SpGerenciarDadosUsuario");
            DataContext.AddParameters("@Operacao", 4, DbType.String);

            var lista = DataContext.ExecuteReader().ToList<DadosUsuario>().ToList();
            return lista;
        }
    }
}
