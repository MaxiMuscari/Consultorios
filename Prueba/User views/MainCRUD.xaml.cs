using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prueba
{
    /// <summary>
    /// Lógica de interacción para MainCRUD.xaml
    /// </summary>
    public partial class MainCRUD : UserControl
    {
        public MainCRUD()
        {
            InitializeComponent();
        }

        private void btnPatients_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPatientUserControl();
        }

        private void btnMedics_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainMedicsUserControl();
        }
    }
}
