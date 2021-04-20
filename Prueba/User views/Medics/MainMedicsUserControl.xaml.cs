using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;


namespace Prueba
{
    /// <summary>
    /// Lógica de interacción para MainMedicsUserControl.xaml
    /// </summary>
    public partial class MainMedicsUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();

        private CollectionViewSource medicViewSource;


        public MainMedicsUserControl()
        {
            InitializeComponent();
            medicViewSource = (CollectionViewSource)FindResource(nameof(medicViewSource));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // load the entities into EF Core
            _context.Medics.Load();

            // bind to the source
            medicViewSource.Source = _context.Medics.Local.ToObservableCollection();

        }

        private void btnAddMedic_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AddMedicUserControl();
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            Refresh();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var x = (Medic)MedicDataGrid.SelectedItem;
            _context.Medics.RemoveRange(x);
            _context.SaveChanges();
            Refresh();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainCRUD();
        }



        public void Refresh()
        {
            MedicDataGrid.Items.Refresh();
        }

    }
}
