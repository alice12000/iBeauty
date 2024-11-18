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
using System.Windows.Shapes;

namespace IBeauty.Telas
{
    /// <summary>
    /// Lógica interna para TabelaAnamneseCapilar.xaml
    /// </summary>
    public partial class TabelaAnamneseCapilar : Page
    {
        public TabelaAnamneseCapilar()
        {
            InitializeComponent();
            CarregarAnamneses();
        }

        private void CarregarAnamneses()
        {
            CadastroDeAnamneseCapilarDAO dao = new CadastroDeAnamneseCapilarDAO();
            List<CadastroDeAnamneseCapilar> anamneses = dao.List();

            var anamnesesExibidas = anamneses.Select(ancap => new
            {
                ID = ancap.Id,
                TipoCabelo = ancap.TipoCabelo,
                Comprimento = ancap.Comprimento,
                Caracteristica = ancap.Caracteristica,
                Elasticidade = ancap.Elasticidade,
                Pigmento = ancap.Pigmento,
                Espessura = ancap.Espessura,
                Observacao = ancap.Observacao,
                Tingimento = ancap.Tingimento,
                Alisamento = ancap.Alisamento,
                Relaxamento = ancap.Relaxamento,
                EscovaProgressiva = ancap.EscovaProgressiva,
                Escova = ancap.Escova,
                Luzes = ancap.Luzes,
                Tinturas = ancap.Tinturas,
                Alisantes = ancap.Alisantes,
                Medicamentos = ancap.Medicamentos,
                LiquidosPermanentes = ancap.LiquidosPermanentes,
                TratamentosCapilares = ancap.TratamentosCapilares,
                Outro = ancap.Outro
            }).ToList();

            dataGridAnamneseCapilar.Items.Clear();
            dataGridAnamneseCapilar.ItemsSource = anamnesesExibidas;
        }


        private void dataGridAnamneseCapilar_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            CadastroDeAnamneseCapilarDAO dao = new CadastroDeAnamneseCapilarDAO();
            List<CadastroDeAnamneseCapilar> anamneses = dao.List();

            var anamnesesExibidas = anamneses.Select(ancap => new
            {
                Id = ancap.Id,
                TipoCabelo = ancap.TipoCabelo,
                Comprimento = ancap.Comprimento,
                Caracteristica = ancap.Caracteristica,
                Elasticidade = ancap.Elasticidade,
                Pigmento = ancap.Pigmento,
                Espessura = ancap.Espessura,
                Observacao = ancap.Observacao,
                Tingimento = ancap.Tingimento,
                Alisamento = ancap.Alisamento,
                Relaxamento = ancap.Relaxamento,
                EscovaProgressiva = ancap.EscovaProgressiva,
                Escova = ancap.Escova,
                Luzes = ancap.Luzes,
                Tinturas = ancap.Tinturas,
                Alisantes = ancap.Alisantes,
                Medicamentos = ancap.Medicamentos,
                TratamentosCapilares = ancap.TratamentosCapilares,
                Outro = ancap.Outro
            }).ToList();

            dataGridAnamneseCapilar.ItemsSource = anamnesesExibidas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroAnamneseCapilar.xaml", UriKind.Relative));
        }

        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {
            CadastroDeAnamneseCapilarDAO dao = new CadastroDeAnamneseCapilarDAO();

            var anamneseSelecionada = dataGridAnamneseCapilar.SelectedItem;

            if (anamneseSelecionada != null)
            {
                int idSelecionado = (int)anamneseSelecionada.GetType().GetProperty("ID").GetValue(anamneseSelecionada);

                CadastroDeAnamneseCapilar anamneseParaExcluir = dao.List().FirstOrDefault(a => a.Id == idSelecionado);

                if (anamneseParaExcluir != null)
                {
                    dao.Delete(anamneseParaExcluir);
                    CarregarAnamneses();
                }
                else
                {
                    MessageBox.Show("Anamnese Capilar não encontrada.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma anamnese capilar para excluir.");
            }
        }

        private void dataGridAnamneses_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // Este método pode ser implementado conforme necessário
        }
        public class AnamneseCapilarExibida
        {
            public int Id { get; set; }
            public string TipoCabelo { get; set; }
            public string Comprimento { get; set; }
            public string Caracteristica { get; set; }
            public string Elasticidade { get; set; }
            public string Pigmento { get; set; }
            public string Espessura { get; set; }
            public string Observacao { get; set; }
            public string Tingimento { get; set; }
            public string Alisamento { get; set; }
            public string Relaxamento { get; set; }
            public string EscovaProgressiva { get; set; }
            public string Escova { get; set; }
            public string Luzes { get; set; }
            public string Tinturas { get; set; }
            public string Alisantes { get; set; }
            public string Medicamentos { get; set; }
            public string TratamentosCapilares { get; set; }
            public string Outro { get; set; }
        }


    }
}
