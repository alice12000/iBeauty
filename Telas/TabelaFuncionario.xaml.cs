using IBeauty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace IBeauty.Telas
{
    /// <summary>
    /// Interação lógica para TabelaFuncionario.xam
    /// </summary>
    public partial class TabelaFuncionario : Page
    {
        public TabelaFuncionario()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
        {
            CadastroDeFuncionarioDAO dao = new CadastroDeFuncionarioDAO();
            List<CadastroDeFuncionario> funcionarios = dao.List();

            var funcionariosExibidos = funcionarios.Select(f => new
            {
                ID = f.Id,
                Nome = f.Nome,
                Telefone = f.Telefone,
                Genero = f.Genero,
                Email = f.Email,
                Observacao = f.Observacao,
                DataNascimento = f.DataNascimento,
                Expediente = f.Expediente,
                Categoria = f.Categoria
            }).ToList();

            dataGridFuncionarios.ItemsSource = funcionariosExibidos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroFuncionario.xaml", UriKind.Relative));
        }

        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {
            CadastroDeFuncionarioDAO dao = new CadastroDeFuncionarioDAO();

            var funcionarioSelecionado = dataGridFuncionarios.SelectedItem;

            if (funcionarioSelecionado != null)
            {
                int idSelecionado = (int)funcionarioSelecionado.GetType().GetProperty("ID").GetValue(funcionarioSelecionado);

                CadastroDeFuncionario funcionarioParaExcluir = dao.List().FirstOrDefault(f => f.Id == idSelecionado);

                if (funcionarioParaExcluir != null)
                {
                    dao.Delete(funcionarioParaExcluir);

                    CarregarFuncionarios();
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
            }
        }

        private void dataGridFuncionarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
