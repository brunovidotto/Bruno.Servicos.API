using System;
using System.Data.Linq.Mapping;

namespace Bruno.Servicos.Dominio.Entidades
{
    public class DadosUsuario
    {
        [Column(Name = "Id")]
        public long Id { get; set; }

        [Column(Name = "Nome")]
        public string Nome { get; set; }

        [Column(Name = "CPF")]
        public long CPF { get; set; }

        [Column(Name = "Email")]
        public string Email { get; set; }

        [Column(Name = "Telefone")]
        public string Telefone { get; set; }

        [Column(Name = "Sexo")]
        public string Sexo { get; set; }

        [Column(Name = "DataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
