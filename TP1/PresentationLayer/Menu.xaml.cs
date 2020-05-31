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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// MENU
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Botão Registar Utente
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistarUtente aux = new RegistarUtente();
        }

        //Botão Editar Utente
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        //Botão Remover Utente
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        //Botão Consultar Registos
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
