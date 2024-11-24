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
    /// Interação lógica para CadastroAnamneseCorporal.xam
    /// </summary>
    public partial class CadastroAnamneseCorporal : Page
    {
        public CadastroAnamneseCorporal()
        {
            InitializeComponent();
        }

        private void bSalvar_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;            
            string perguntaDepilacao = cbJaDepilou.Text;
            string respostaDepilacao = tbSimDepilacao.Text;
            string perguntaAlergia = cbOcorreuAlergia.Text; 
            string respostaAlergia = tbSimOcorreuAlergia.Text; 
            string perguntaAlergia2 = cbPossuiAlergia.Text; 
            string respostaAlergia2 = tbSimPossuiAlergia.Text;
            string perguntaProblema = cbProblemaPele.Text; 
            string respostaProblema = tbsimProblemaPele.Text;
            string perguntaTratamento = cbEstaemTratamento.Text;
            string respostaTratamento = tbSimTratamento.Text;
            string perguntaGestante = cbGestante.Text;
            string respostaGestante = tbSimGravida.Text;
            string perguntaVasos = cbVasosVarizes.Text;
            string tipoPele = tbTipoPele.Text;
            

            string ceraQuente = cbCeraQuente.IsChecked == true ? "Sim" : "Não"; 
            string ceraFria = cbCeraFria.IsChecked == true ? "Sim" : "Não"; 
            string laser = cbLaser.IsChecked == true ? "Sim" : "Não";  
            string luzPulsante = cbLuzPulsante.IsChecked == true ? "Sim" : "Não";
            string linha = cbLinha.IsChecked == true ? "Sim" : "Não";

            string axilas = cbAxilas.IsChecked == true ? "Sim" : "Não";
            string virilha = cbVirilha.IsChecked == true ? "Sim" : "Não";
            string costa = cbCosta.IsChecked == true ? "Sim" : "Não";
            string peito = cbPeitoAbdomem.IsChecked == true ? "Sim" : "Não";
            string braco = cbBraco.IsChecked == true ? "Sim" : "Não";
            string costaPerna = cbCostaPerna.IsChecked == true ? "Sim" : "Não";
            string nadegas = cbNadegasExtras.IsChecked == true ? "Sim" : "Não";

            if (perguntaAlergia == "Sim")
            {
                tbSimOcorreuAlergia.IsEnabled = true;
                respostaAlergia = tbSimOcorreuAlergia.Text;
            }
            else if(perguntaAlergia == "Não")
            {
                tbSimOcorreuAlergia.Text = string.Empty;
                tbSimOcorreuAlergia.IsEnabled = false;
                respostaAlergia = "";
            }
            if (perguntaDepilacao == "Sim")
            {
                tbSimOcorreuAlergia.IsEnabled = true;
                respostaAlergia = tbSimOcorreuAlergia.Text;
            }
            else if (perguntaAlergia == "Não")
            {
                tbSimOcorreuAlergia.Text = string.Empty;
                tbSimOcorreuAlergia.IsEnabled = false;
                respostaAlergia = "";
            }
            if (perguntaAlergia2 == "Sim")
            {
                tbSimPossuiAlergia.IsEnabled = true;
                respostaAlergia2 = tbSimPossuiAlergia.Text;
            }
            else if (perguntaAlergia2 == "Não")
            {
                tbSimPossuiAlergia.Text = string.Empty;
                tbSimPossuiAlergia.IsEnabled = false;
                respostaAlergia2 = "";
            }

            if (perguntaProblema == "Sim")
            {
                tbsimProblemaPele.IsEnabled = true;
                respostaProblema = tbsimProblemaPele.Text;
            }
            else if (perguntaProblema == "Não")
            {
                tbsimProblemaPele.Text = string.Empty;
                tbsimProblemaPele.IsEnabled = false;
                respostaProblema = "";
            }

            if (perguntaTratamento == "Sim")
            {
                tbSimTratamento.IsEnabled = true;
                respostaTratamento = tbSimTratamento.Text;
            }
            else if (perguntaTratamento == "Não")
            {
                tbSimTratamento.Text = string.Empty;
                tbSimTratamento.IsEnabled = false;
                respostaTratamento = "";
            }

            if (perguntaGestante == "Sim")
            {
                tbSimGravida.IsEnabled = true;
                respostaGestante = tbSimGravida.Text;
            }
            else if (perguntaGestante == "Não")
            {
                tbSimGravida.Text = string.Empty;
                tbSimGravida.IsEnabled = false;
                respostaGestante = "";
            }
            CadastroDeAnamneseCorporal anamnese = new CadastroDeAnamneseCorporal(id, perguntaDepilacao, respostaDepilacao, perguntaAlergia, respostaAlergia, perguntaAlergia2,
            respostaAlergia2, perguntaProblema, respostaProblema, perguntaTratamento, respostaTratamento, perguntaGestante, respostaGestante, perguntaVasos, tipoPele,
            ceraQuente, ceraFria, laser, luzPulsante, linha, axilas, virilha, costa, peito, braco, costaPerna, nadegas);

            if (string.IsNullOrWhiteSpace(perguntaDepilacao) || string.IsNullOrWhiteSpace(respostaDepilacao) ||
            string.IsNullOrWhiteSpace(perguntaAlergia) || string.IsNullOrWhiteSpace(respostaAlergia) ||
            string.IsNullOrWhiteSpace(perguntaAlergia2) || string.IsNullOrWhiteSpace(respostaAlergia2) ||
            string.IsNullOrWhiteSpace(perguntaProblema) || string.IsNullOrWhiteSpace(respostaProblema) ||
            string.IsNullOrWhiteSpace(perguntaTratamento) || string.IsNullOrWhiteSpace(respostaTratamento) ||
            string.IsNullOrWhiteSpace(perguntaGestante) || string.IsNullOrWhiteSpace(respostaGestante) ||
            string.IsNullOrWhiteSpace(perguntaVasos) || string.IsNullOrWhiteSpace(tipoPele) ||
            !cbCeraQuente.IsChecked.HasValue || !cbCeraFria.IsChecked.HasValue || !cbLaser.IsChecked.HasValue ||
            !cbLuzPulsante.IsChecked.HasValue || !cbLinha.IsChecked.HasValue || !cbAxilas.IsChecked.HasValue ||
            !cbVirilha.IsChecked.HasValue || !cbCosta.IsChecked.HasValue || !cbPeitoAbdomem.IsChecked.HasValue ||
            !cbBraco.IsChecked.HasValue || !cbCostaPerna.IsChecked.HasValue || !cbNadegasExtras.IsChecked.HasValue)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }


            MessageBox.Show("Passando os parametros");
            

            var dao = new CadastroDeAnamneseCorporalDAO();
            dao.Insert(anamnese);
            NavigationService.Navigate(new Uri("Telas/TabelaAnamneseCorporal.xaml", UriKind.Relative));
        }
        private void bFechar_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
