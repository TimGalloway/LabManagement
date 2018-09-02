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

namespace LabManagementWPF
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        public Clients()
        {
            InitializeComponent();
            List<Client> items = new List<Client>();
            items.Add(new Client() { ID = 1, Name = "TestClient1", Address = "1 Here Street" });
            items.Add(new Client() { ID = 2, Name = "TestClient2", Address = "2 Here Street" });
            items.Add(new Client() { ID = 3, Name = "TestClient3", Address = "3 Here Street" });
            lvClients.ItemsSource = items;
        }
    }
}
