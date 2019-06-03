using System;

namespace Bruno.Servicos.Utilitario
{
    public class ExcecaoHelper
    {
        /// <summary>
        /// Retorna a mensagem de exceção completa, incluindo as inner exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ObterMensagemExcecaoCompleta(Exception ex)
        {
            var erro = "";
            var excecao = ex;

            while (excecao != null)
            {
                erro = excecao.Message;
                excecao = excecao.InnerException;
            }

            return erro;
        }

        public static Exception ObterMensagemExcecaoRaiz(Exception ex)
        {
            var excecao = ex;
            var erroRetorno = new Exception();

            while (excecao != null)
            {
                erroRetorno = excecao;
                excecao = excecao.InnerException;
            }

            return erroRetorno;
        }

    }
}