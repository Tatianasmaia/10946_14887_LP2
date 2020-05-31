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
        private void Registar(object sender, RoutedEventArgs e)
        {
            RegistarUtente aux = new RegistarUtente();
        }

        //Botão Editar Utente
        private void Editar(object sender, RoutedEventArgs e)
        {

        }

        //Botão Remover Utente
        private void Remover(object sender, RoutedEventArgs e)
        {

        }

        //Botão Consultar Registos
        private void Consultar(object sender, RoutedEventArgs e)
        {

        }

      
        private void TextBox_TextChanged_Nome(object sender, TextChangedEventArgs e)
        {
             if (!string.IsNullOrWhiteSpace(TextBox_TextChanged_Nome.Text)) Utilizadores.currentUser.Username = textBox1.Text;
        }
    }
}
