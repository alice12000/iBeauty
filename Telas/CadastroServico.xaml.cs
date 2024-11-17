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
    public partial class CadastroServico : Page
    {
        private CadastroDeFuncionarioDAO funcionarioDAO = new CadastroDeFuncionarioDAO();

        public CadastroServico()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validações dos campos de entrada
                string nomeServico = servico_txt.Text;
                string descricao = descricao_txt.Text;
                int retorno;
                TimeSpan duracao;

                if (!int.TryParse(retorno_txt.Text, out retorno))
                {
                    MessageBox.Show("Por favor, insira um número válido para o campo 'Retorno'.");
                    return;
                }
                if (!TimeSpan.TryParse(duracao_txt.Text, out duracao))
                {
                    MessageBox.Show("Por favor, insira um número válido para o campo 'Duração'.");
                    return;
                }

                double precoUnitario;
                if (!double.TryParse(precounitario_txt.Text, out precoUnitario))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para o campo 'Preço Unitário'.");
                    return;
                }

                double comissao;
                if (!double.TryParse(comissao_txt.Text, out comissao))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para o campo 'Comissão'.");
                    return;
                }

                // Cálculo do preço final
                double precovenda = precoUnitario + (precoUnitario * (comissao / 100));
                precofinal_txt.Text = precovenda.ToString("F2");

                // Verifica se um número foi selecionado no ComboBox
                if (int.TryParse(funcionario_cbx.Text, out int funcionarioId))
                {
                    // Criação do objeto de serviço
                    var servico = new CadastroDeServico(0, descricao, categoria_cbx.Text, precoUnitario, comissao, funcionarioId, retorno, duracao, precovenda, nomeServico);

                    // Salvando o serviço
                    var servicoDAO = new CadastroDeServicoDAO();
                    servicoDAO.Insert(servico);

                    MessageBox.Show("Serviço cadastrado com sucesso!");
                    NavigationService.Navigate(new Uri("Telas/TabelaServico.xaml", UriKind.Relative));
                }

                else
                {
                    MessageBox.Show("Falha ao cadastrar o serviço");
                }
   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar as informações do serviço: " + ex.Message);
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Detalhes do erro: " + ex.StackTrace);
            }
        }
    }
}
