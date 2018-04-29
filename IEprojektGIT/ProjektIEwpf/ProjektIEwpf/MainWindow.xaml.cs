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
using System.Data.OleDb;

namespace ProjektIEwpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\projekty\Jajebiekolejny\IEprojektGIT\Database5.accdb");
            con.Open();
            string queryString = "SELECT * FROM Produkt";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RekomendowaneLstbx.Items.Add(reader.GetString(1)+ ", " + reader.GetString(2) + ", " + reader.GetValue(3));
            }

            

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Zaawansowane_Click(object sender, RoutedEventArgs e)
        {

            Window Zaawansowane = new DetailedSearch();
            Zaawansowane.Show();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ObejrzyjBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RekomendowaneLstbx.SelectedValue!=null)
            {
                Window obejrzyj = new Window();
            }
            
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RekomendowaneLstbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void M1_Click(object sender, RoutedEventArgs e)
        {
            Window W1 = new MainWindow();
            W1.Show();
        }

        private void M2_Click(object sender, RoutedEventArgs e)
        {
            SklepOkno W1 = new SklepOkno();
            W1.Show();
        }
    }
}
