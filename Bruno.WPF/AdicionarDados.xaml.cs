using Bruno.WPF.Entidades;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bruno.WPF
{
    [ImplementPropertyChanged]
    public partial class AdicionarDados : Window
    {
        public DadosUsuario dadosUsuario { get; set; }
        public List<TipoSexo> listGenero { get; set; }
        public string genero { get; set; }

        public AdicionarDados()
        {
            InitializeComponent();

            DataContext = this;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidarDados();

                if (btnCadastrar.Content.Equals("Cadastrar"))
                {
                    Servico.Integracao.AdicionarUsuario(dadosUsuario);
                    MessageBox.Show("Cadastrado com sucesso!!");
                }
                else
                {
                    Servico.Integracao.AtualizarUsuario(dadosUsuario);
                    MessageBox.Show("Atualizado com sucesso!!");
                }

                Servico.Integracao.BuscarListaUsuarios();
                Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                try { erro = (JsonConvert.DeserializeObject<Retorno>(ex.Message)).exceptionMessage; } catch { }

                MessageBox.Show(erro);
            }
        }
        private void ValidarDados()
        {
            dadosUsuario.Sexo = genero;

            if (String.IsNullOrEmpty(dadosUsuario.Nome))
                throw new Exception("O campo nome é obrigatório!");

            if (dadosUsuario.CPF == 0)
                throw new Exception("O campo CPF é obrigatório!");

            if (String.IsNullOrEmpty(dadosUsuario.Email))
                throw new Exception("O campo Email é obrigatório!");

            if (String.IsNullOrEmpty(dadosUsuario.Telefone))
                throw new Exception("O campo telefone é obrigatório!");

            if (dadosUsuario.DataNascimento == DateTime.MinValue)
                throw new Exception("O campo Data de Nascimento é obrigatório!");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (dadosUsuario == null)
            {
                dadosUsuario = new DadosUsuario();
            }
            else
            {
                txtCPF.IsEnabled = false;
                txtEmail.IsEnabled = false;
            }
            

            listGenero = new List<TipoSexo>();
            listGenero.Add(new TipoSexo { genero = "Masculino" });
            listGenero.Add(new TipoSexo { genero = "Feminino" });

            if (!String.IsNullOrEmpty(dadosUsuario.Sexo))
            {
                if (dadosUsuario.Sexo == "Masculino")
                    cmbSexo.SelectedIndex = 0;
                else
                    cmbSexo.SelectedIndex = 1;                
            }
                   
        }
    }
}
