using IBeauty.Models;
using Microsoft.Win32;
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
    /// Interação lógica para CadastroProduto.xam
    /// </summary>
    public partial class CadastroProduto : Page
    {
        public CadastroProduto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nomeProduto = produto_txt.Text;
                string descricao = descricao_txt.Text;
                int unidades = 0;

                if (!int.TryParse(unidades_txt.Text, out unidades))
                {
                    MessageBox.Show("Por favor, insira um número válido para o campo 'Unidades'.");
                    return;
                }

                double precoUnitario = 0;
                if (!double.TryParse(precounitario_txt.Text, out precoUnitario))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para o campo 'Preço Unitário'.");
                    return;
                }

                double comissao = 0;
                if (!double.TryParse(comissao_txt.Text, out comissao))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para o campo 'Comissão'.");
                    return;
                }

                double precovenda = precoUnitario + (precoUnitario * (comissao / 100));
                precofinal_txt.Text = precovenda.ToString("F2");

                var produto = new CadastroDeProduto(0, nomeProduto, unidades, descricao, precoUnitario, comissao, precovenda);

                // Agora, você pode continuar com a lógica de salvar o produto
                var produtoDAO = new CadastroDeProdutoDAO();
                produtoDAO.Insert(produto);

                MessageBox.Show("Produto cadastrado com sucesso!");
                NavigationService.Navigate(new Uri("Telas/TabelaProduto.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Detalhes do erro: " + ex.StackTrace);
                throw new Exception("Erro ao salvar as informações do produto: " + ex.Message);
            }
        }

    }
}