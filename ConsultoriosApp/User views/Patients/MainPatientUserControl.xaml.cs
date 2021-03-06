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


namespace ConsultoriosApp
{
    /// <summary>
    /// Lógica de interacción para SearchUserControl.xaml
    /// </summary>
    public partial class MainPatientUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();

        private CollectionViewSource pacientViewSource;



        public MainPatientUserControl()
        {
            InitializeComponent();
            pacientViewSource = (CollectionViewSource)FindResource(nameof(pacientViewSource));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // load the entities into EF Core
            _context.Patients.Load();

            // bind to the source
            pacientViewSource.Source = _context.Patients.Local.ToObservableCollection();


        }
        private void btnAddPacient_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AddPatientUserControl();
        }
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)PatientDataGrid.SelectedItem;
            Application.Current.MainWindow.Content = new ModifyPatientUserControl(patient);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var patient = (Patient)PatientDataGrid.SelectedItem;
            _context.Patients.RemoveRange(patient);
            _context.SaveChanges();

            Search();
            Refresh();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainCRUD();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.Key == Key.Return)
            {
                Search();
            }
        }

        public void Refresh()
        {
            PatientDataGrid.Items.Refresh();
        }

        private void Search()
        {
            var search = txtSearch.Text.ToLower();
            pacientViewSource.Source = _context.Patients
                                             .Where(x => x.Name.ToLower().Contains(search) ||
                                             x.Surname.ToLower().Contains(search) ||
                                             x.DNI.ToLower().Contains(search) ||
                                             x.MedicalSecurity.ToLower().Contains(search) ||
                                             x.PhoneNumber.ToLower().Contains(search) ||
                                             x.Address.ToLower().Contains(search))
                                             .ToList();
        }

    }
}
