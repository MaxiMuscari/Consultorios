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
            var medic = (Medic)MedicDataGrid.SelectedItem;
            _context.Medics.RemoveRange(medic);
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


        private List<Especialities> GetPosibleEspecialities(string search)
        {
            List<Especialities> especialities = new List<Especialities>();

            var array = Enum.GetValues(typeof(Especialities));

            foreach (Especialities especiality in array)
            {
                if (especiality.ToString().ToLower().Contains(search))
                {
                    especialities.Add(especiality);
                }
            }

            return especialities;
        }


        public void Refresh()
        {
            MedicDataGrid.Items.Refresh();
        }

        private void Search()
        {
            var search = txtSearch.Text.ToLower();

            medicViewSource.Source = _context.Medics
                   .AsEnumerable()
                   .Where(x => x.Name.ToLower().Contains(search) ||
                       x.Surname.ToLower().Contains(search) ||
                       x.DNI.ToLower().Contains(search) ||
                       x.CUIL.ToLower().Contains(search) ||
                       x.PhoneNumber.ToLower().Contains(search) ||
                       GetPosibleEspecialities(search).Any(e => e == x.Especialities))
                   .ToList();
        }

    }
}
