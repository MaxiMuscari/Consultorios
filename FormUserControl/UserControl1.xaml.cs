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

namespace FormUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void WebFrame_Navigated(object sender, EventArgs e)
        { }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WebFrame.Source = new Uri(this.UserSource.Text, UriKind.Absolute);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}