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
    /// Interação lógica para CadastroCliente.xam
    /// </summary>
    public partial class CadastroCliente : Page
    {
        public Frame MainFrame { get; set; }
        public CadastroCliente()
        {
            InitializeComponent();
        }
        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    rua_txt.Text = "";
            //    bairro_txt.Text = "";
            //    numero_txt.Text = "";
            //    complemento_txt.Text = "";
            //    cidade_txt.Text = "";
            //    estado_txt.Text = "";
            //    cep_txt.Text = "";
            //    numero_telefone_txt.Text = "";
            //    user_txt.Text = "";
            //    senha_txt.Text = "";

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Window novaJanela = new Window
            {
                Content = new CadastroAnamneseCapilar(), // Defina aqui a nova Page
                Width = 800,
                Height = 600,
                Owner = Application.Current.MainWindow, // Define a janela principal como proprietária
                WindowStartupLocation = WindowStartupLocation.CenterOwner // Centraliza a nova janela
            };

            // Exibe a janela como modal
            novaJanela.ShowDialog();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (cadAnamneseCorporal.Visibility == Visibility.Collapsed)
            {
                cadAnamneseCorporal.Visibility = Visibility.Visible;
            }
            else
            {
                cadAnamneseCorporal.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            
        }

        private string anamneseCapilar;
        private string anamneseCorporal;

        private void btnCadastrarAnamneseCorporal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnCadastroCliente_Click(object sender, RoutedEventArgs e)
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

            string rua = tbrua.Text;
            string bairro = tbbairro.Text;
            int numero = 0;

            if (!int.TryParse(tbnumero.Text, out numero))
            {
                MessageBox.Show("Por favor, insira um número válido para o campo 'Número'.");
                return;
            }

            string complemento = tbcomplemento.Text;
            string cidade = tbcidade.Text;
            string estado = cbestado.Text;

            string nome = tbnome.Text;
            string telefone = tbcelular.Text;
            string genero = cbgenero.Text;
            string email = tbemail.Text;
            string cpf = tbcpf.Text;
            string dataNascimento = tbdn.Text;

            string cep = tbcep.Text;

            if (string.IsNullOrWhiteSpace(tipoCabelo) || string.IsNullOrWhiteSpace(comprimento) ||
                string.IsNullOrWhiteSpace(caracteristica) || string.IsNullOrWhiteSpace(elasticidade) ||
                string.IsNullOrWhiteSpace(pigmento) || string.IsNullOrWhiteSpace(espessura) ||
                string.IsNullOrWhiteSpace(observacao) || string.IsNullOrWhiteSpace(perguntaDepilacao) || string.IsNullOrWhiteSpace(respostaDepilacao) ||
            string.IsNullOrWhiteSpace(perguntaAlergia) || string.IsNullOrWhiteSpace(respostaAlergia) ||
            string.IsNullOrWhiteSpace(perguntaAlergia2) || string.IsNullOrWhiteSpace(respostaAlergia2) ||
            string.IsNullOrWhiteSpace(perguntaProblema) || string.IsNullOrWhiteSpace(respostaProblema) ||
            string.IsNullOrWhiteSpace(perguntaTratamento) || string.IsNullOrWhiteSpace(respostaTratamento) ||
            string.IsNullOrWhiteSpace(perguntaGestante) || string.IsNullOrWhiteSpace(respostaGestante) ||
            string.IsNullOrWhiteSpace(perguntaVasos) || string.IsNullOrWhiteSpace(tipoPele) ||
            !cbCeraQuente.IsChecked.HasValue || !cbCeraFria.IsChecked.HasValue || !cbLaser.IsChecked.HasValue ||
            !cbLuzPulsante.IsChecked.HasValue || !cbLinha.IsChecked.HasValue || !cbAxilas.IsChecked.HasValue ||
            !cbVirilha.IsChecked.HasValue || !cbCosta.IsChecked.HasValue || !cbPeitoAbdomem.IsChecked.HasValue ||
            !cbBraco.IsChecked.HasValue || !cbCostaPerna.IsChecked.HasValue || !cbNadegasExtras.IsChecked.HasValue ||
            string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(genero) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(dataNascimento) ||
                string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(bairro) ||
                string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado) || numero == 0)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            else
            {
                var anamneseCapilar = new CadastroDeAnamneseCapilarDAO();



                MessageBox.Show("Passando os parametros");
                CadastroDeAnamneseCapilar anamneseCap = new CadastroDeAnamneseCapilar(
                0, tipoCabelo, comprimento, caracteristica, elasticidade, pigmento, espessura, observacao,
                tingimento, alisamento, relaxamento, escovaProgressiva, escova, luzes, tinturas, alisantes,
                medicamentos, liquido, tratamento, outro);

                var daoCap = new CadastroDeAnamneseCapilarDAO();
                daoCap.Insert(anamneseCap);




                if (perguntaAlergia == "Sim")
                {
                    tbSimOcorreuAlergia.IsEnabled = true;
                    respostaAlergia = tbSimOcorreuAlergia.Text;
                }
                else
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
                else
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
                else 
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
                else
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
                else
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
                else 
                {
                    tbSimGravida.Text = string.Empty;
                    tbSimGravida.IsEnabled = false;
                    respostaGestante = "";
                }
                CadastroDeAnamneseCorporal anamneseCor = new CadastroDeAnamneseCorporal(id, perguntaDepilacao, respostaDepilacao, perguntaAlergia, respostaAlergia, perguntaAlergia2,
                respostaAlergia2, perguntaProblema, respostaProblema, perguntaTratamento, respostaTratamento, perguntaGestante, respostaGestante, perguntaVasos, tipoPele,
                ceraQuente, ceraFria, laser, luzPulsante, linha, axilas, virilha, costa, peito, braco, costaPerna, nadegas);


                MessageBox.Show("Passando os parametros");


                var daoCor = new CadastroDeAnamneseCorporalDAO();
                daoCor.Insert(anamneseCor);

                var endereco = new Endereco(0, rua, bairro, numero, complemento, cidade, estado, cep);

                var enderecoDAO = new EnderecoDAO();
                enderecoDAO.Insert(endereco);

                var cliente = new Cliente(0, nome, dataNascimento, genero, email, cpf, telefone, endereco, anamneseCap, anamneseCor);

                var clienteDAO = new ClienteDAO();
                clienteDAO.Insert(cliente);

                MessageBox.Show("Cliente cadastrado com sucesso!");

                NavigationService.Navigate(new Uri("Telas/TabelaCliente.xaml", UriKind.Relative));
            }
        }

        private void btnCadastrarAnamneseCapilar_Click(object sender, RoutedEventArgs e)
        {
            if (cadAnamneseCapilar.Visibility == Visibility.Collapsed)
            {
                cadAnamneseCapilar.Visibility = Visibility.Visible;
            }
            else
            {
                cadAnamneseCapilar.Visibility = Visibility.Collapsed;
            }
        }

        private void bFechar_Click(object sender, RoutedEventArgs e)
        {
            if (cadAnamneseCorporal.Visibility == Visibility.Visible)
            {
                cadAnamneseCorporal.Visibility = Visibility.Collapsed;
            }
            else
            {
                cadAnamneseCorporal.Visibility = Visibility.Visible;
            }
        }

        private void bSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bFechar2_Click(object sender, RoutedEventArgs e)
        {
            if (cadAnamneseCapilar.Visibility == Visibility.Visible)
            {
                cadAnamneseCapilar.Visibility = Visibility.Collapsed;
            }
            else
            {
                cadAnamneseCapilar.Visibility = Visibility.Visible;
            }
        }
    }
}

