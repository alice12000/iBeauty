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
    /// Interação lógica para TabelaServico.xam
    /// </summary>
    public partial class TabelaServico : Page
    {
        public TabelaServico()
        {
            InitializeComponent();
            CarregarServicos();
        }
        private void CarregarServicos()
        {
            CadastroDeServicoDAO dao = new CadastroDeServicoDAO();
            List<CadastroDeServico> servico = dao.List();
            /*       
        public int Retorno { get; set; }
        public int Duracao { get; set; }
        public double PrecoFinal { get; private set; }*/

            var servicosExibidos = servico.Select(s => new
            {
                ID = s.Id,
                Servico = s.Servico,
                Descricao = s.Descricao,
                Categoria = s.Categoria,
                PrecoUnitario = s.PrecoUnitario,
                Comissao = s.Comissao,
                Funcionario = s.Funcionario,
                Retorno = s.Retorno,
                Duracao = s.Duracao,
                PrecoFinal = s.PrecoFinal

            }).ToList();


            dataGridServicos.ItemsSource = servicosExibidos;
        }


        private void dataGridServicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CadastroDeServicoDAO dao = new CadastroDeServicoDAO();

            List<CadastroDeServico> servicos = dao.List();

            dataGridServicos.ItemsSource = servicos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroServico.xaml", UriKind.Relative));
        }

        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {
            try
            {
                // Instância do DAO
                CadastroDeServicoDAO dao = new CadastroDeServicoDAO();

                // Verificando se há um item selecionado no DataGrid
                var servicoSelecionado = dataGridServicos.SelectedItem;

                if (servicoSelecionado != null)
                {
                    int idSelecionado = (int)servicoSelecionado.GetType().GetProperty("ID").GetValue(servicoSelecionado);

                    CadastroDeServico servicoParaExcluir = dao.List().FirstOrDefault(p => p.Id == idSelecionado);

                    if (servicoParaExcluir != null)
                    {
                        dao.Delete(servicoParaExcluir);

                        CarregarServicos();
                    }
                    else
                    {
                        MessageBox.Show("Serviço não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um serviço para excluir.");
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
