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
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Cadastro : Page
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/TelaInicial.xaml", UriKind.Relative));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                string rua = tbrua.Text;
                string bairro = tbbairro.Text;
                int numero = 0;

                if (!int.TryParse(tbnumero.Text, out numero))
                {
                    MessageBox.Show("Por favor, insira um número válido para o campo 'Número'.");
                    return;
                }

                string complemento = tbcomplemento.Text;
                string cidade = tbcidade.Text;
                string estado = cbestado.Text;
                string cep = tbcep.Text;

                if (string.IsNullOrWhiteSpace(tbnome.Text) || string.IsNullOrWhiteSpace(tbemail.Text) || string.IsNullOrWhiteSpace(tbsenha.Text) ||
                    string.IsNullOrWhiteSpace(tbtelefone.Text) || string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(bairro) ||
                    string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado) || numero == 0)
                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return;
                }

                var endereco = new Endereco(0, rua, bairro, numero, complemento, cidade, estado, cep);

                var enderecoDAO = new EnderecoDAO();
                enderecoDAO.Insert(endereco); 

                string nome = tbnome.Text;
                string dataNascimento = tbdn.Text;
                string senha = tbsenha.Text;
                string genero = cbgenero.Text;
                string email = tbemail.Text;
                string telefone = tbtelefone.Text;

                var cadastroUsuario = new CadastroUsuario(0, nome, dataNascimento, senha, genero, email, telefone, endereco);

                var cadastroUsuarioDAO = new CadastroUsuarioDAO();
                cadastroUsuarioDAO.Insert(cadastroUsuario);

                MessageBox.Show("Usuário cadastrado com sucesso!");
                NavigationService.Navigate(new Uri("Telas/Login.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar usuário: " + ex.ToString());
                throw new Exception("Erro ao salvar as informações: " + ex.Message, ex.InnerException);
            }
        }   

    }
}
