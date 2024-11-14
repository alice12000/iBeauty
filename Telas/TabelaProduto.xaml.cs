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

        private void ExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            CadastroDeProdutoDAO dao = new CadastroDeProdutoDAO();

            var produtoSelecionado = (CadastroDeProduto)dataGridProdutos.SelectedItem;
            if (produtoSelecionado != null)
            {

                dao.Delete(produtoSelecionado); 
                List<CadastroDeProduto> produtosAtualizados = dao.List();  // Ou o método adequado para obter todos os produtos
                dataGridProdutos.ItemsSource = produtosAtualizados;  // Atualiza a lista no DataGrid
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.");
            }
        }

        private void Button_CadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroProduto.xaml", UriKind.Relative));
        }
    }
}
