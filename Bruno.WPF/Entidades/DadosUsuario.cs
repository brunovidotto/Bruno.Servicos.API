using PropertyChanged;
using System;

namespace Bruno.WPF.Entidades
{
    [ImplementPropertyChanged]
    public class DadosUsuario
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
