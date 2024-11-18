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
    /// Interação lógica para TabelaCliente.xam
    /// </summary>
    public partial class TabelaCliente : Page
    {
        public TabelaCliente()
        {
            InitializeComponent();
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            ClienteDAO dao = new ClienteDAO();
            List<Cliente> clientes = dao.ListarClientes();

            var clientesExibidos = clientes.Select(c => new
            {
                ID = c.Id,
                Nome = c.Nome,
                Celular = c.Celular,
                Genero = c.Genero,
                Email = c.Email,
                DataNascimento = c.DataNascimento,

                // Informações de Endereço
                EnderecoRua = c.Endereco?.Rua,
                EnderecoBairro = c.Endereco?.Bairro,
                EnderecoNumero = c.Endereco?.Numero,
                EnderecoCidade = c.Endereco?.Cidade,
                EnderecoEstado = c.Endereco?.Estado,
                EnderecoCep = c.Endereco?.Cep,

                // Informações de Anamnese Capilar
                AnamneseTipoCabelo = c.AnamneseCapilar?.TipoCabelo,
                AnamneseComprimento = c.AnamneseCapilar?.Comprimento,
                AnamneseElasticidade = c.AnamneseCapilar?.Elasticidade,
                AnamnesePigmento = c.AnamneseCapilar?.Pigmento,
                AnamneseEspessura = c.AnamneseCapilar?.Espessura,
                AnamneseObservacao = c.AnamneseCapilar?.Observacao,

                // Informações de Anamnese Corporal
                AnamnesePerguntaDepilacao = c.AnamneseCorporal?.PerguntaDepilacao,
                AnamneseRespostaDepilacao = c.AnamneseCorporal?.RespostaDepilacao,
                AnamnesePerguntaAlergia = c.AnamneseCorporal?.PerguntaAlergia,
                AnamneseRespostaAlergia = c.AnamneseCorporal?.RespostaAlergia,
                AnamnesePerguntaProblema = c.AnamneseCorporal?.PerguntaProblema,
                AnamneseRespostaProblema = c.AnamneseCorporal?.RespostaProblema
            }).ToList();

            dataGridCliente.ItemsSource = clientesExibidos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroCliente.xaml", UriKind.Relative));
        }

        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {
            
        }

        private void dataGridClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dataGridExpediente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            List<Cliente> clientes = dao.ListarClientes();

            var clientesExibidos = clientes.Select(c => new
            {
                ID = c.Id,
                Nome = c.Nome,
                Celular = c.Celular,
                Genero = c.Genero,
                Email = c.Email,
                DataNascimento = c.DataNascimento,

                // Informações de Endereço
                EnderecoRua = c.Endereco?.Rua,
                EnderecoBairro = c.Endereco?.Bairro,
                EnderecoNumero = c.Endereco?.Numero,
                EnderecoCidade = c.Endereco?.Cidade,
                EnderecoEstado = c.Endereco?.Estado,
                EnderecoCep = c.Endereco?.Cep,

                // Informações de Anamnese Capilar
                AnamneseTipoCabelo = c.AnamneseCapilar?.TipoCabelo,
                AnamneseComprimento = c.AnamneseCapilar?.Comprimento,
                AnamneseElasticidade = c.AnamneseCapilar?.Elasticidade,
                AnamnesePigmento = c.AnamneseCapilar?.Pigmento,
                AnamneseEspessura = c.AnamneseCapilar?.Espessura,
                AnamneseObservacao = c.AnamneseCapilar?.Observacao,

                // Informações de Anamnese Corporal
                AnamnesePerguntaDepilacao = c.AnamneseCorporal?.PerguntaDepilacao,
                AnamneseRespostaDepilacao = c.AnamneseCorporal?.RespostaDepilacao,
                AnamnesePerguntaAlergia = c.AnamneseCorporal?.PerguntaAlergia,
                AnamneseRespostaAlergia = c.AnamneseCorporal?.RespostaAlergia,
                AnamnesePerguntaProblema = c.AnamneseCorporal?.PerguntaProblema,
                AnamneseRespostaProblema = c.AnamneseCorporal?.RespostaProblema
            }).ToList();

            dataGridCliente.ItemsSource = clientesExibidos;
        }
    }
}

