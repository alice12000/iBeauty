using IBeauty.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace IBeauty.Telas
{
    public partial class CadastroServico : Page
    {
        private CadastroDeFuncionarioDAO funcionarioDAO = new CadastroDeFuncionarioDAO();

        public CadastroServico()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
        {
            try
            {
                List<CadastroDeFuncionario> funcionarios = funcionarioDAO.List();
                if (funcionarios != null && funcionarios.Count > 0)
                {
                    funcionario_cbx.ItemsSource = funcionarios;
                    funcionario_cbx.DisplayMemberPath = "Nome"; // Nome a ser exibido
                    funcionario_cbx.SelectedValuePath = "Id";   // ID para uso como chave
                }
                else
                {
                    MessageBox.Show("Nenhum funcionário encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validações dos campos de entrada
                string nomeServico = servico_txt.Text;
                string descricao = descricao_txt.Text;
                int retorno = 0;
                int duracao = 0;

                if (!int.TryParse(retorno_txt.Text, out retorno))
                {
                    MessageBox.Show("Por favor, insira um número válido para o campo 'Retorno'.");
                    return;
                }
                if (!int.TryParse(duracao_txt.Text, out duracao))
                {
                    MessageBox.Show("Por favor, insira um número válido para o campo 'Duração'.");
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

                // Cálculo do preço final
                double precovenda = precoUnitario + (precoUnitario * (comissao / 100));
                precofinal_txt.Text = precovenda.ToString("F2");

                // Verifica se um funcionário foi selecionado
                if (funcionario_cbx.SelectedItem is CadastroDeFuncionario selectedFuncionario)
                {
                    int funcionarioId = selectedFuncionario.Id;

                    // Criação do objeto de serviço
                    var servico = new CadastroDeServico(0, descricao, categoria_cbx.Text, precoUnitario, comissao, funcionarioId, retorno, duracao, precovenda, nomeServico);

                    // Salvando o serviço
                    var servicoDAO = new CadastroDeServicoDAO();
                    servicoDAO.Insert(servico);

                    MessageBox.Show("Produto cadastrado com sucesso!");
                    NavigationService.Navigate(new Uri("Telas/TabelaProduto.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um funcionário.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Detalhes do erro: " + ex.StackTrace);
                throw new Exception("Erro ao salvar as informações do serviço: " + ex.Message);
            }
        }
    }
}
