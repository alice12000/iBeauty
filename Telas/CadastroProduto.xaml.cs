﻿using Microsoft.Win32;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IBeauty.Telas
{
    /// <summary>
    /// Lógica interna para CaadastroProduto.xaml
    /// </summary>
    public partial class CadastroProduto : Window
    {
        private bool isAnamneseExpanded = false;
        private bool isMenuExpanded = false;
        public CadastroProduto()
        {
            InitializeComponent();
        }
        private void BtnToggleMenu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };

            if (isMenuExpanded)
            {
                animation.From = MenuPanel.ActualWidth;
                animation.To = 0;

                animation.Completed += (s, a) =>
                {
                    MenuPanel.Visibility = Visibility.Collapsed;
                };
            }
            else
            {
                MenuPanel.Visibility = Visibility.Visible;

                animation.From = 0;
                animation.To = 250;
            }

            MenuPanel.BeginAnimation(FrameworkElement.WidthProperty, animation);
            isMenuExpanded = !isMenuExpanded;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            TelaInicial inicio = new TelaInicial();
            inicio.Show();
            this.Close();
        }
        private void BtnAnamnese_Click(object sender, RoutedEventArgs e)
        {
            isAnamneseExpanded = !isAnamneseExpanded;
            AnamneseOptions.Visibility = isAnamneseExpanded ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnAnamneseCapilar_Click(object sender, RoutedEventArgs e)
        {
            CadastroAnamneseCapilar CAC = new CadastroAnamneseCapilar();
            CAC.Show();
            this.Close();
        }

        private void BtnAnamneseCorporal_Click(object sender, RoutedEventArgs e)
        {
            CadastroAnamneseCorporal CACO = new CadastroAnamneseCorporal();
            CACO.Show();
            this.Close();
        }

        private void BtnAnamneseFacial_Click(object sender, RoutedEventArgs e)
        {
            CadastroAnamneseFacial CAF = new CadastroAnamneseFacial();
            CAF.Show();
            this.Close();
        }

        private void BtnAnamneseManicure_Click(object sender, RoutedEventArgs e)
        {
            CadastroAnamneseManicurePedicure CAMP = new CadastroAnamneseManicurePedicure();
            CAMP.Show();
            this.Close();
        }
        private void BtnCadastroFuncionario_Click(object sender, RoutedEventArgs e)
        {
            CadastroFuncionario CFU = new CadastroFuncionario();
            CFU.Show();
            this.Close();
        }
        private void BtnCadastroCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastroCliente CCL = new CadastroCliente();
            CCL.Show();
            this.Close();
        }
        private void BtnCadastroExpediente_Click(object sender, RoutedEventArgs e)
        {
            CadastroExpediente CEX = new CadastroExpediente();
            CEX.Show();
            this.Close();
        }
        private void BtnCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnCadastroFornecedor_Click(object sender, RoutedEventArgs e)
        {
            CadastroFornecedor CFOR = new CadastroFornecedor();
            CFOR.Show();
            this.Close();
        }
        private void BtnServico_Click(object sender, RoutedEventArgs e)
        {
            /*
            Servico SE = new Servico();
            SE.Show();
            this.Close(); */
        }

        private void BtnCarregarImagem_Click(object sender, RoutedEventArgs e)
        {//pegar a imagem do produto
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Imagens (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == true)
                {
                    //exibir a imagem selecionada
                    string caminhoArquivo = openFileDialog.FileName;
                    BitmapImage bitmap = new BitmapImage(new Uri(caminhoArquivo, UriKind.Absolute));
                    ImgCarregada.Source = bitmap;
                    //esconde o botão de carregar a imagem 
                    BtnCarregarImagem.Visibility = Visibility.Collapsed;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
