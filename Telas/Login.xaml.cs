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
            // Captura os valores de email e senha dos campos de entrada
            string email = tbemail.Text;
            string senha = tbsenha.Text;

            // Verifica se o campo de email ou senha está vazio
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Verifica se o usuário existe e se a senha está correta
            
                // Chama o método de autenticação passando o e-mail e a senha
                Usuario usuario = _usuarioDAO.AuthenticateUser(email, senha);

                if (usuario != null)
                {
                    MessageBox.Show("Login bem-sucedido!");
                    // Aqui você pode redirecionar o usuário para outra página após o login
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos. Tente novamente.");
                }
            
            
        }


    }
}
