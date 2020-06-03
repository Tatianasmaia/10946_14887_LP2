using System.Windows;
using System.Windows.Controls;


namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botão Registar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registar_Click(object sender, RoutedEventArgs e)
        {
            RegistarUtente expenseReportPage = new RegistarUtente();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            MenuEditar expenseReportPage = new MenuEditar();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Remover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            RemoverUtente expenseReportPage = new RemoverUtente();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Consultar Utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultarUtente expenseReportPage = new ConsultarUtente();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Consultar utentes pela idade introduzida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarIdade_Click(object sender, RoutedEventArgs e)
        {
            ConsultarIdades expenseReportPage = new ConsultarIdades();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Consultar Região
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarRegiao_Click(object sender, RoutedEventArgs e)
        {
            ConsultarRegiao expenseReportPage = new ConsultarRegiao();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Consultar Sexo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarSexo_Click(object sender, RoutedEventArgs e)
        {
            ConsultarSexo expenseReportPage = new ConsultarSexo();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão Consultar Utentes Infetados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarInfetados_Click(object sender, RoutedEventArgs e)
        {
            ConsultarInfetados expenseReportPage = new ConsultarInfetados();
            this.NavigationService.Navigate(expenseReportPage);
        }

        /// <summary>
        /// Botão consultar Historico de utentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarHistorico_Click(object sender, RoutedEventArgs e)
        {
            ConsultarHistorico expenseReportPage = new ConsultarHistorico();
            this.NavigationService.Navigate(expenseReportPage);
        }
        
        /// <summary>
        /// Botão Sair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}
