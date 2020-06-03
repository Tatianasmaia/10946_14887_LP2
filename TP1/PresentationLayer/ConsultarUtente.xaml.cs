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
using BO;
using BR;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for ConsultarUtente.xaml
    /// </summary>
    public partial class ConsultarUtente : Page
    {
        public ConsultarUtente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botão Consultar (o utente com o respetivo nif inserido)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            List<Utente> listaAuxiliar = new List<Utente>();

            int nif = Int32.Parse(tb_nif.Text);

            listaAuxiliar = Rules.SearchPatient(nif);

            if (listaAuxiliar.Count == 0)
            {
                MessageBox.Show("Não existe nenhum utente com esse nif!");
            }
            else
            {
                dataGridUtente.ItemsSource = listaAuxiliar;
            }


        }
    }
}
