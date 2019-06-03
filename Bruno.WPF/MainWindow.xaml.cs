using Bruno.Servicos.Utilitario;
using Bruno.WPF.Entidades;
using Bruno.WPF.Servico;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Bruno.WPF
{
    [ImplementPropertyChanged]
    public partial class MainWindow : Window
    {        
        public ObservableCollection<DadosUsuario> ListaDadosUsuario { get; set; }    
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = this;

                ListaDadosUsuario = Integracao.BuscarListaUsuarios();              
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }     
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dadoUsuario = (DadosUsuario)dtGridUsuarios.SelectedValue;

                if (MessageBox.Show("Tem certeza que deseja remover o registro?", "Atenção a Mensagem", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Integracao.ExcluirUsuario(dadoUsuario.Id);
                    ListaDadosUsuario = Integracao.BuscarListaUsuarios();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new AdicionarDados().ShowDialog();
                ListaDadosUsuario = Integracao.BuscarListaUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dadoUsuario = (DadosUsuario)dtGridUsuarios.SelectedValue;

                var user = new AdicionarDados();
                user.dadosUsuario = dadoUsuario;
                user.btnCadastrar.Content = "Atualizar";

                user.ShowDialog();
                ListaDadosUsuario = Integracao.BuscarListaUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
