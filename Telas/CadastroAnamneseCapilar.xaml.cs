    using IBeauty.Database;
    using IBeauty.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
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
        /// Interação lógica para CadastroAnamneseCapilar.xam
        /// </summary>
        public partial class CadastroAnamneseCapilar : Page
        {
            public CadastroAnamneseCapilar()
            {
                InitializeComponent();
        }

            private void bFechar_Click(object sender, RoutedEventArgs e)
            {

                Window.GetWindow(this)?.Close();
            }

        private void bSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botaoclicado");

            string tipoCabelo = cbtipoCabelo.Text;
            string comprimento = tbComprimento.Text;
            string caracteristica = cbCaracteristica.Text;
            string elasticidade = tbElasticidade.Text;
            string pigmento = tbpigmento.Text;
            string espessura = tbEspessura.Text;
            string observacao = tbObservacao.Text;

            string tingimento = cbTingimento.IsChecked == true ? "Sim" : "Não";
            string alisamento = cbAlisamento.IsChecked == true ? "Sim" : "Não";
            string relaxamento = cbRelaxamento.IsChecked == true ? "Sim" : "Não";
            string escovaProgressiva = cbEscovaProgressiva.IsChecked == true ? "Sim" : "Não";
            string escova = cbEscova.IsChecked == true ? "Sim" : "Não";
            string luzes = cbLuzes.IsChecked == true ? "Sim" : "Não";
            string tinturas = cbTinturas.IsChecked == true ? "Sim" : "Não";
            string alisantes = cbAlisantes.IsChecked == true ? "Sim" : "Não";
            string medicamentos = cbMedicamentos.IsChecked == true ? "Sim" : "Não";
            string liquido = cbLiqPermanentes.IsChecked == true ? "Sim" : "Não";
            string tratamento = cbTratamentosCapilares.IsChecked == true ? "Sim" : "Não";
            string outro = cbOutro.IsChecked == true ? "Sim" : "Não";

            if (string.IsNullOrWhiteSpace(tipoCabelo) || string.IsNullOrWhiteSpace(comprimento) ||
                string.IsNullOrWhiteSpace(caracteristica) || string.IsNullOrWhiteSpace(elasticidade) ||
                string.IsNullOrWhiteSpace(pigmento) || string.IsNullOrWhiteSpace(espessura) ||
                string.IsNullOrWhiteSpace(observacao))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }     
                MessageBox.Show("Passando os parametros");
                CadastroDeAnamneseCapilar anamnese = new CadastroDeAnamneseCapilar(
                0, tipoCabelo, comprimento, caracteristica, elasticidade, pigmento, espessura, observacao,
                tingimento, alisamento, relaxamento, escovaProgressiva, escova, luzes, tinturas, alisantes,
                medicamentos, liquido, tratamento, outro);

                var dao = new CadastroDeAnamneseCapilarDAO();
                dao.Insert(anamnese);
                NavigationService.Navigate(new Uri("Telas/TabelaAnamneseCapilar.xaml", UriKind.Relative));
        }

        private void LimparCampos()
            {
                cbtipoCabelo.SelectedIndex = -1;
                tbComprimento.Clear();
                cbCaracteristica.SelectedIndex = -1;
                tbElasticidade.Clear();
                tbpigmento.Clear();
                tbEspessura.Clear();
                tbObservacao.Clear();

                cbTingimento.IsChecked = false;
                cbAlisamento.IsChecked = false;
                cbRelaxamento.IsChecked = false;
                cbEscovaProgressiva.IsChecked = false;
                cbEscova.IsChecked = false;
                cbLuzes.IsChecked = false;
                cbTinturas.IsChecked = false;
                cbAlisantes.IsChecked = false;
                cbMedicamentos.IsChecked = false;
                cbOutro.IsChecked = false;
            }
        }
    }
