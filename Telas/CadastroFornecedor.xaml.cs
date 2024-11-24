using IBeauty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Interação lógica para CadastroFornecedor.xam
    /// </summary>
    public partial class CadastroFornecedor : Page
    {
        public CadastroFornecedor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cpfCnpj = tbcpfcnpj.Text;
                Verificacoes verificar = new Verificacoes();

                if (rbCpf.IsChecked == true)
                {
                    if (!verificar.ValidarCpf(cpfCnpj))
                    {
                        MessageBox.Show("Por favor, insira um CPF válido.");
                        return;
                    }
                }
                else if (rbCnpj.IsChecked == true)
                {
                    if (!verificar.ValidarCnpj(cpfCnpj))
                    {
                        MessageBox.Show("Por favor, insira um CNPJ válido.");
                        return;
                    }
                }
                else
                {

                    string rua = tbrua.Text;
                    string bairro = tbbairro.Text;
                    int numero;

                    if (!int.TryParse(tbnumero.Text, out numero))
                    {
                        MessageBox.Show("Por favor, insira um número válido para o campo 'Número'.");
                        return;
                    }

                    string complemento = tbcomplemento.Text;
                    string cidade = tbcidade.Text;
                    string estado = cbestado.Text;
                    string cep = tbcep.Text;

                    if (string.IsNullOrWhiteSpace(tbnome.Text) || string.IsNullOrWhiteSpace(tbempresa.Text) || string.IsNullOrWhiteSpace(cpfCnpj) ||
                        string.IsNullOrWhiteSpace(tbtelefone.Text) || string.IsNullOrWhiteSpace(tbwebsite.Text) || string.IsNullOrWhiteSpace(rua) ||
                        string.IsNullOrWhiteSpace(bairro) || string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado) || numero == 0)
                    {
                        MessageBox.Show("Por favor, preencha todos os campos.");
                        return;
                    }

                    var endereco = new Endereco(0, rua, bairro, numero, complemento, cidade, estado, cep);

                    var enderecoDAO = new EnderecoDAO();
                    enderecoDAO.Insert(endereco);

                    string nome = tbnome.Text;
                    string empresa = tbempresa.Text;
                    string telefone = tbtelefone.Text;
                    string webSite = tbwebsite.Text;

                    var cadastroDoFornecedor = new CadastroDoFornecedor(0, nome, empresa, cpfCnpj, telefone, webSite, endereco);

                    var cadastroDoFornecedorDAO = new CadastroDoFornecedorDAO();
                    cadastroDoFornecedorDAO.Insert(cadastroDoFornecedor);

                    MessageBox.Show("Usuário cadastrado com sucesso!");

                    NavigationService.Navigate(new Uri("Telas/TabelaFornecedor.xaml", UriKind.Relative));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw new Exception("Erro ao salvar as informações: " + ex.Message);
            }
        }

    }
}
