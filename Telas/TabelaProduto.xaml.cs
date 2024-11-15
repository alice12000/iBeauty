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
    /// Interação lógica para TabelaProduto.xam
    /// </summary>
    public partial class TabelaProduto : Page
    {
        public TabelaProduto()
        {
            InitializeComponent();
            CarregarProdutos();
        }
        private void CarregarProdutos()
        {
            CadastroDeProdutoDAO dao = new CadastroDeProdutoDAO();
            List<CadastroDeProduto> produtos = dao.List();

            var produtosExibidos = produtos.Select(p => new
            {
                ID = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Unidades = p.Unidades,
                PrecoUnitario = p.PrecoUnitario,
                Comissao = p.Comissao,
                PrecoFinal = p.PrecoFinal

            }).ToList();


            dataGridProdutos.ItemsSource = produtosExibidos;
        }


        private void dataGridProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CadastroDeProdutoDAO dao = new CadastroDeProdutoDAO();

            List<CadastroDeProduto> produtos = dao.List();

            dataGridProdutos.ItemsSource = produtos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroProduto.xaml", UriKind.Relative));
        }
        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {
            try
            {
                // Instância do DAO
                CadastroDeProdutoDAO dao = new CadastroDeProdutoDAO();

                // Verificando se há um item selecionado no DataGrid
                var produtoSelecionado = dataGridProdutos.SelectedItem;

                if (produtoSelecionado != null)
                {
                    int idSelecionado = (int)produtoSelecionado.GetType().GetProperty("ID").GetValue(produtoSelecionado);

                    CadastroDeProduto produtoParaExcluir = dao.List().FirstOrDefault(p => p.Id == idSelecionado);

                    if (produtoParaExcluir != null)
                    {
                        dao.Delete(produtoParaExcluir);

                        CarregarProdutos();
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um produto para excluir.");
                }
            }
            catch (Exception ex)
            {
                // Exibe a mensagem de erro em caso de falha
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}