using Bruno.Servicos.DTO;
using Bruno.Servicos.Facade.Contrato;
using Bruno.Servicos.Utilitario;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bruno.Servicos.API.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [ResponseType(typeof(IList<DadosUsuarioDTO>))]
        [HttpGet]
        [Route("buscarLista")]
        public IHttpActionResult BuscarLista()
        {
            var facade = DependencyFactory.Resolve<IDadosFacade>();
            var retorno = facade.BuscarLista();

            if (retorno.Count == 0)
                new RetornoDTO { Message = "dados não encontrado" };

            return Ok(retorno);
        }


        [ResponseType(typeof(IList<DadosUsuarioDTO>))]
        [HttpGet]
        [Route("buscarPorId")]
        public IHttpActionResult BuscarPorId(long id)
        {
            var facade = DependencyFactory.Resolve<IDadosFacade>();
            var retorno = facade.BuscarPorId(id);

            if (retorno.Count == 0)
                new RetornoDTO { Message = "dados não encontrado" };

            return Ok(retorno);
        }

        [ResponseType(typeof(IList<DadosUsuarioDTO>))]
        [HttpGet]
        [Route("buscarPorNome")]
        public IHttpActionResult BuscarPorNome(string nome)
        {
            var facade = DependencyFactory.Resolve<IDadosFacade>();
            var retorno = facade.BuscarPorNome(nome);

            if (retorno.Count == 0)
                new RetornoDTO { Message = "dados não encontrado" };

            return Ok(retorno);
        }

        [ResponseType(typeof(IList<DadosUsuarioDTO>))]
        [HttpGet]
        [Route("buscarPorCPF")]
        public IHttpActionResult BuscarPorCPF(long CPF)
        {
            var facade = DependencyFactory.Resolve<IDadosFacade>();
            var retorno = facade.BuscarPorCPF(CPF);

            if (retorno.Count == 0)
                new RetornoDTO { Message = "dados não encontrado" };

            return Ok(retorno);
        }

        [ResponseType(typeof(DadosUsuarioDTO))]
        [HttpPost]
        [Route("cadastrar")]
        public IHttpActionResult Cadastrar(DadosUsuarioDTO requisicao)
        {
            if (requisicao == null)
            {
                return BadRequest();
            }

            var facade = DependencyFactory.Resolve<IDadosFacade>();
            facade.Cadastrar(requisicao);           

            return Ok(new RetornoDTO { Message = "cadastrado com sucesso" });
        }

        [ResponseType(typeof(DadosUsuarioDTO))]
        [HttpPut]
        [Route("atualizar")]
        public IHttpActionResult Atualizar(DadosUsuarioDTO requisicao)
        {
            if (requisicao == null)
            {
                return BadRequest();
            }

            var facade = DependencyFactory.Resolve<IDadosFacade>();
            facade.Atualizar(requisicao);

            return Ok(new RetornoDTO { Message = "atualizado com sucesso" });
        }

        [ResponseType(typeof(DadosUsuarioDTO))]
        [HttpDelete]
        [Route("excluir")]
        public IHttpActionResult Excluir(long id)
        {
            var facade = DependencyFactory.Resolve<IDadosFacade>();
            facade.Excluir(id);

            return Ok(new RetornoDTO { Message = "excluido com sucesso" });
        }
    }
}