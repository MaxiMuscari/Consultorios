using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ConsultoriosApp
{
    /// <summary>
    /// Lógica de interacción para MainTurnUserControl.xaml
    /// </summary>
    public partial class MainTurnUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();

        private CollectionViewSource turnViewSource;

        public MainTurnUserControl()
        {
            InitializeComponent();

            turnViewSource = (CollectionViewSource)FindResource(nameof(turnViewSource));

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            // load the entities into EF Core
            _context.Turns.Load();

            // bind to the source
            turnViewSource.Source = _context.Turns.Local.ToObservableCollection();

        }

        private void btnAddTurn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AddTurnUserControl();
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            Turn turn = (Turn)TurnDataGrid.SelectedItem;
            Application.Current.MainWindow.Content = new ModifyTurnUserControl(turn);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var turn = (Turn)TurnDataGrid.SelectedItem;
            _context.Turns.RemoveRange(turn);
            _context.SaveChanges();
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

        private void Refresh()
        {
            TurnDataGrid.Items.Refresh();
        }
        private void Search()
        {
            
            var search = txtSearch.Text.ToLower();

            turnViewSource.Source = _context.Turns
                   .AsEnumerable()
                   .Where(x => x.Patient.Name.ToLower().Contains(search) ||
                       x.Patient.Surname.ToLower().Contains(search) ||
                       x.Patient.DNI.ToLower().Contains(search) ||
                       x.Medic.Name.ToLower().Contains(search) ||
                       x.Medic.Surname.ToLower().Contains(search) ||
                       x.Schedule.Date.ToString("dd/MM/yyyy").Contains(search)
                       )
                   .ToList();
        }

    }
}
