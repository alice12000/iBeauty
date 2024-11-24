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
    /// Interação lógica para InformacoesUsuario.xam
    /// </summary>
    public partial class InformacoesUsuario : Page
    {
        public InformacoesUsuario()
        {
            InitializeComponent();
            _cadastroDAO = new CadastroUsuarioDAO();

            //CarregarDadosUsuario(usuarioId);
        }
        private CadastroUsuarioDAO _cadastroDAO;

        private void CarregarDadosUsuario(int usuarioId)
        {
            tbnome.IsEnabled = false;
            tbgenero.IsEnabled = false;
            tbemail.IsEnabled = false;
            tbdn.IsEnabled = false;
            tbtelefone.IsEnabled = false;
            tbrua.IsEnabled = false;
            tbbairro.IsEnabled = false;
            tbnumero.IsEnabled = false;
            tbcep.IsEnabled = false;
            tbcidade.IsEnabled = false;
            tbestado.IsEnabled = false;
            tbcomplemento.IsEnabled = false;

            try
            {
                var usuario = _cadastroDAO.GetById(usuarioId);

                if (usuario != null)
                {
                    tbnome.Text = usuario.Nome;
                    tbgenero.Text = usuario.Genero;
                    tbemail.Text = usuario.Email;
                    tbdn.Text = usuario.DataNascimento;
                    tbtelefone.Text = usuario.Telefone;
                    tbrua.Text = usuario.Endereco.Rua;
                    tbbairro.Text = usuario.Endereco.Bairro;
                    tbcidade.Text = usuario.Endereco.Cidade;
                    tbcep.Text = usuario.Endereco.Cep;
                    tbnumero.Text = usuario.Endereco.Numero.ToString(); 
                    tbestado.Text = usuario.Endereco.Estado;
                    tbcomplemento.Text = usuario.Endereco.Complemento;
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
