using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruno.Servicos.DTO
{
    public class DadosUsuarioDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
