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
    /// Interação lógica para TabelaFornecedor.xam
    /// </summary>
    public partial class TabelaFornecedor : Page
    {
        public TabelaFornecedor()
        {
            InitializeComponent();
            CarregarFornecedores();
        }
        private void CarregarFornecedores()
        {
            CadastroDoFornecedorDAO dao = new CadastroDoFornecedorDAO();
            List<CadastroDoFornecedor> fornecedores = dao.List();

            var fornecedoresExibidos = fornecedores.Select(f => new
            {
                ID = f.Id,
                Nome = f.Nome,
                Empresa = f.Empresa,
                CPF_ou_CNPJ = f.CpfCnpj,
                Telefone = f.Telefone,
                Website = f.Website,
                Rua = f.Endereco.Rua,
                Bairro = f.Endereco.Bairro,
                Numero = f.Endereco.Numero,
                Complemento = f.Endereco.Complemento,
                Cidade = f.Endereco.Cidade,
                Estado = f.Endereco.Estado,
                CEP = f.Endereco.Cep
            }).ToList();

            dataGridFornecedores.ItemsSource = fornecedoresExibidos;
        }


        private void dataGridFornecedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CadastroDoFornecedorDAO dao = new CadastroDoFornecedorDAO();
            List<CadastroDoFornecedor> fornecedores = dao.List();

            var fornecedoresExibidos = fornecedores.Select(f => new
            {
                ID = f.Id,
                Nome = f.Nome,
                Empresa = f.Empresa,
                CPF_ou_CNPJ = f.CpfCnpj,
                Telefone = f.Telefone,
                Website = f.Website,
                Rua = f.Endereco.Rua,
                Bairro = f.Endereco.Bairro,
                Numero = f.Endereco.Numero,
                Complemento = f.Endereco.Complemento,
                Cidade = f.Endereco.Cidade,
                Estado = f.Endereco.Estado,
                CEP = f.Endereco.Cep
            }).ToList();

            dataGridFornecedores.ItemsSource = fornecedoresExibidos;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroFornecedor.xaml", UriKind.Relative));
        }

        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {
            CadastroDoFornecedorDAO dao = new CadastroDoFornecedorDAO();

            var fornecedorSelecionado = dataGridFornecedores.SelectedItem;

            if (fornecedorSelecionado != null)
            {
                int idSelecionado = (int)fornecedorSelecionado.GetType().GetProperty("ID").GetValue(fornecedorSelecionado);

                CadastroDoFornecedor fornecedorParaExcluir = dao.List().FirstOrDefault(f => f.Id == idSelecionado);

                if (fornecedorParaExcluir != null)
                {
                    dao.Delete(fornecedorParaExcluir);

                    CarregarFornecedores();
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para excluir.");
            }
        }
    }
}
