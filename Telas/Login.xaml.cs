using IBeauty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IBeauty.Controle;
using IBeauty.Telas;


namespace IBeauty.Telas
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        private UsuarioDAO _usuarioDAO = new UsuarioDAO();

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = tbemail.Text; 
                string senha = tbsenha.Text;

                UsuarioDAO usuarioAutenticado = new UsuarioDAO();
                usuarioAutenticado.AuthenticateCadastro(email, senha);

                if (usuarioAutenticado != null)
                {
                    MessageBox.Show("Login bem-sucedido!");

                    JanelaPrincipal janelaPrincipal = new JanelaPrincipal();

                    janelaPrincipal.MainFrame.Navigate(new TelaInicialSistema());

                    janelaPrincipal.menuLogin.Visibility = Visibility.Collapsed;
                    janelaPrincipal.menuControl.Visibility = Visibility.Visible;

                    Application.Current.MainWindow = janelaPrincipal;
                    janelaPrincipal.Show();
                    Window.GetWindow(this)?.Close();
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos. Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o login: " + ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            JanelaPrincipal janelaPrincipal = new JanelaPrincipal();
            janelaPrincipal.MainFrame.Navigate(new Cadastro());
        }
    }
}
