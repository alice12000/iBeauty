using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace IBeauty.Controle
{
    public partial class MenuControl : UserControl
    {

        private bool isAnamneseExpanded = false;
        private bool isMenuExpanded = false;

        public Frame MainFrame { get; set; }

        public MenuControl()
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

        private void BtnAnamneseCapilar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroAnamneseCapilar());
        }

        private void BtnAnamneseCorporal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroAnamneseCorporal());
        }

        private void BtnAnamneseFacial_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroAnamneseFacial());
        }

        private void BtnAnamneseManicure_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroAnamneseManicurePedicure());
        }

        private void BtnCadastroFuncionario_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroFuncionario());
        }

        private void BtnCadastroCliente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroCliente());
        }

        private void BtnCadastroExpediente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroExpediente());
        }

        private void BtnCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroProduto());
        }

        private void BtnCadastroFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaFornecedor());
        }

        private void BtnCadastrarServico_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.CadastroServico());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnAnamnese_Click(object sender, RoutedEventArgs e)
        {
            isAnamneseExpanded = !isAnamneseExpanded;
            AnamneseOptions.Visibility = isAnamneseExpanded ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
