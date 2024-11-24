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
    /// Interação lógica para CadastrodeCategoria.xam
    /// </summary>
    public partial class CadastroCategoria : Page
    {
        public CadastroCategoria()
        {
            InitializeComponent();
        }

        //cadastrar categoria
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string tipo = "";

                if (rb_servico.IsChecked == true)
                {
                    tipo = Convert.ToString(rb_servico);
                }
                else if (rb_produto.IsChecked == true)
                {
                    tipo = Convert.ToString(rb_produto);
                }
                else
                {
                    MessageBox.Show("Por favor selecione algum dos campos serviço ou produto");
                }
                string nome = categoria_txt.Text;
                // Verifica se um número foi selecionado no ComboBox
                if (int.TryParse(funcionario_cbx.Text, out int funcionarioId))
                {

                    var categoria = new CadastroDeCategoria(nome, tipo, funcionarioId);

                    var categoriaDAO = new CadastroDeCategoriaDAO();
                    categoriaDAO.Insert(categoria);

                    MessageBox.Show("Categoria cadastrado com sucesso!");
                }

                else
                {
                    MessageBox.Show("Falha ao salvar os dados de categoria");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                throw new Exception("Erro ao salvar as informações: " + ex.Message);
            }

        }
    }
}