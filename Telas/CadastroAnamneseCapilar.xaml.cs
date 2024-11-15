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
            // Verificação dos campos obrigatórios
            if (cbtipoCabelo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione o tipo de cabelo.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbComprimento.Text))
            {
                MessageBox.Show("Por favor, insira o comprimento do cabelo.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cbCaracteristica.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione a característica do cabelo.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbElasticidade.Text))
            {
                MessageBox.Show("Por favor, insira a elasticidade do cabelo.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbpigmento.Text))
            {
                MessageBox.Show("Por favor, insira o pigmento predominante.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbEspessura.Text))
            {
                MessageBox.Show("Por favor, insira a espessura do fio.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbObservacao.Text))
            {
                MessageBox.Show("Por favor, insira alguma observação.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Verificação de pelo menos uma condição marcada
            if (!cbTingimento.IsChecked.GetValueOrDefault() &&
                !cbAlisamento.IsChecked.GetValueOrDefault() &&
                !cbRelaxamento.IsChecked.GetValueOrDefault() &&
                !cbEscovaProgressiva.IsChecked.GetValueOrDefault() &&
                !cbEscova.IsChecked.GetValueOrDefault() &&
                !cbLuzes.IsChecked.GetValueOrDefault())
            {
                MessageBox.Show("Por favor, selecione pelo menos uma condição capilar.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Verificação de pelo menos um antecedente alérgico marcado
            if (!cbTinturas.IsChecked.GetValueOrDefault() &&
                !cbAlisantes.IsChecked.GetValueOrDefault() &&
                !cbMedicamentos.IsChecked.GetValueOrDefault() &&
                !cbLiqPermanetes.IsChecked.GetValueOrDefault() &&
                !cbTratamentosCapila.IsChecked.GetValueOrDefault() &&
                !cbOutro.IsChecked.GetValueOrDefault())
            {
                MessageBox.Show("Por favor, selecione pelo menos um antecedente alérgico.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            // Criação do objeto a ser salvo no banco de dados

            string tipoCabelo = cbtipoCabelo.Text; 
            string comprimento = tbComprimento.Text;
            string caracteristica = cbCaracteristica.Text;
            string elasticidade = tbElasticidade.Text;
            string pigmento = tbpigmento.Text;
            string espessura = tbEspessura.Text;
            string observacao = tbObservacao.Text;     
            bool tingimento = cbTingimento.IsChecked.GetValueOrDefault();
            bool alisamento = cbAlisamento.IsChecked.GetValueOrDefault();
            bool relaxamento = cbRelaxamento.IsChecked.GetValueOrDefault();
            bool escovaProgressiva = cbEscovaProgressiva.IsChecked.GetValueOrDefault();
            bool escova = cbEscova.IsChecked.GetValueOrDefault();
            bool luzes = cbLuzes.IsChecked.GetValueOrDefault();
            bool tinturas = cbTinturas.IsChecked.GetValueOrDefault();
            bool alisantes = cbAlisantes.IsChecked.GetValueOrDefault();
            bool medicamentos = cbMedicamentos.IsChecked.GetValueOrDefault();
            bool liqPermanentes = cbLiqPermanetes.IsChecked.GetValueOrDefault();
            bool tratamentosCapilares = cbTratamentosCapila.IsChecked.GetValueOrDefault();
            bool outro = cbOutro.IsChecked.GetValueOrDefault();

            var anamnese = new CadastroDeAnamneseCapilar(0, tipoCabelo, comprimento, caracteristica, elasticidade, pigmento, espessura, observacao,
                tingimento, alisamento, relaxamento, escovaProgressiva, escova, luzes, tinturas, alisantes, medicamentos, liqPermanentes, tratamentosCapilares, outro);

            var cadastroDeAnamneseCapilarDAO = new CadastroDeAnamneseCapilarDAO();
            cadastroDeAnamneseCapilarDAO.Insert(anamnese);


            // Aqui você pode adicionar a lógica de salvar os dados no banco de dados
            MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            // Após salvar, navegar de volta para a tela de cadastro de cliente
            Window.GetWindow(this)?.Close();


        }

        // Método para limpar os campos após o salvamento
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
            cbLiqPermanetes.IsChecked = false;
            cbTratamentosCapila.IsChecked = false;
            cbOutro.IsChecked = false;
        }
    }
}
