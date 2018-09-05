using LabManagementWPF;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LabManagmentWPF
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        public Clients()
        {
            InitializeComponent();
            var context = new LabManagementWPF_model();
            var clients = context.Clients.Select(x => x).ToList();
            lvClients.ItemsSource = clients;
        }

        private void lvClients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var context = new LabManagementWPF_model();
            ListView a = (ListView)sender;
            Client b = (Client)a.SelectedItem;
            this.vbClient.DataContext = b;
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            Client b = (Client)sender;
            //using (var db = new LabManagementWPF_model())
            //{
            //    var result = db.Clients.SingleOrDefault(b => b.ID == sender.ID);
            //    if (result != null)
            //    {
            //        result.
            //    }
            //}
        }
    }
}
