using IBeauty.Telas;
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
            MainFrame.Navigate(new Telas.TabelaAnamneseCapilar());
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
            MainFrame.Navigate(new Telas.TabelaFuncionario());
        }

        private void BtnCadastroCliente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaCliente());
        }

        private void BtnCadastroExpediente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaExpediente());
        }

        private void BtnCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaProduto());
        }

        private void BtnCadastroFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaFornecedor());
        }

        private void BtnCadastrarServico_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaServico());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnAnamnese_Click(object sender, RoutedEventArgs e)
        {
            isAnamneseExpanded = !isAnamneseExpanded;
            AnamneseOptions.Visibility = isAnamneseExpanded ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnDesconectar_Click(object sender, RoutedEventArgs e)
        {
            JanelaPrincipal janelaPrincipal = new JanelaPrincipal();

            janelaPrincipal.MainFrame.Navigate(new TelaInicial());

            janelaPrincipal.menuLogin.Visibility = Visibility.Visible;
            janelaPrincipal.menuControl.Visibility = Visibility.Collapsed;

            Application.Current.MainWindow = janelaPrincipal;
            janelaPrincipal.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
