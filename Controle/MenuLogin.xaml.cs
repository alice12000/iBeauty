using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace IBeauty.Controle
{
    public partial class MenuLogin : UserControl
    {
        private bool isMenuExpanded = false;
        public Frame MainFrame { get; set; }

        public MenuLogin()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

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

        private void BtnCadastro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.Cadastro());
        }
        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TelaInicial());
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.Login());
        }
        public void FecharMenu()
        {
            if (isMenuExpanded)
            {
                BtnToggleMenu_Click(null, null);
            }
        }


    }
}
