﻿using IBeauty.Models;
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
    /// Interação lógica para CadastroFuncionario.xam
    /// </summary>
    public partial class CadastroFuncionario : Page
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            string email = tbemail.Text;
            Verificacoes verificar = new Verificacoes();

            if (email != "")
            {
                if (!verificar.ValidarEmail(email))
                {
                    MessageBox.Show("Por favor, insira um Email válido.");
                    return;
                }


                else
                {
                    string categoriaSelecionada = "";
                    if (rdcabelo.IsChecked == true)
                    {
                        categoriaSelecionada = "Cabelo";
                    }
                    else if (rdunha.IsChecked == true)
                    {
                        categoriaSelecionada = "Unha";
                    }
                    else if (rdrosto.IsChecked == true)
                    {
                        categoriaSelecionada = "Rosto";
                    }
                    else if (rdcorpo.IsChecked == true)
                    {
                        categoriaSelecionada = "Corpo";
                    }
                    string nome = tbnome.Text;
                    string telefone = tbtelefone.Text;
                    string genero = cbgenero.Text;
                    string observacao = tbobservacao.Text;
                    string dataNascimento = tbdn.Text;
                    string expediente = cbexpediente.Text;

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
                    string cep = tbcep.Text;

                    if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(genero) ||
                        string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(observacao) || string.IsNullOrWhiteSpace(dataNascimento) ||
                        string.IsNullOrWhiteSpace(expediente) || string.IsNullOrWhiteSpace(categoriaSelecionada) ||
                        string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(bairro) ||
                        string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado) || numero == 0)
                    {
                        MessageBox.Show("Por favor, preencha todos os campos.");
                        return;
                    }

                    var endereco = new Endereco(0, rua, bairro, numero, complemento, cidade, estado, cep);

                    var enderecoDAO = new EnderecoDAO();
                    enderecoDAO.Insert(endereco);

                    var cadastroFuncionario = new CadastroDeFuncionario(0, nome, telefone, genero, email, observacao, dataNascimento, expediente, categoriaSelecionada, endereco);

                    var cadastroFuncionarioDAO = new CadastroDeFuncionarioDAO();
                    cadastroFuncionarioDAO.Insert(cadastroFuncionario);

                    MessageBox.Show("Funcionário cadastrado com sucesso!");

                    NavigationService.Navigate(new Uri("Telas/TabelaFuncionario.xaml", UriKind.Relative));
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }

        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroExpediente.xaml", UriKind.Relative));
        }
    }
}