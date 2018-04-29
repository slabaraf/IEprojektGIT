﻿using System;
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
    /// Interaction logic for SklepPage.xaml
    /// </summary>
    public partial class SklepPage : Page
    {
        public SklepPage()
        {
            InitializeComponent();
            int NumberOfProducts = 0;
            string fileName = "Database5.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();

            string queryString = "SELECT [Nazwa], [Producent] FROM Produkt";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

           

            while (reader.Read())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(reader.GetValue(0) + ", " + reader.GetValue(1));
                lb_products.Items.Add(sb);
                NumberOfProducts++;
            }

            reader.Close();
        }

        private void Obejrzyj_Click(object sender, RoutedEventArgs e)
        {
            ProductsCheckout.Id = lb_products.SelectedIndex+1;
            if (ProductsCheckout.Id>0)
            {
                this.NavigationService.Navigate(new Uri("Pages/OgladanieProduktuPage.xaml", UriKind.Relative));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

