using practice_2_dataset.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

namespace practice_2_dataset
{
    public partial class MainWindow : Window
    {

        ReadersTableAdapter readers = new ReadersTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            dg_BD_readers.ItemsSource = readers.GetData();
            dg_BD_readers.DisplayMemberPath = "ReaderName";
        }

        private void dg_BD_readers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var reader = (dg_BD_readers.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(reader.ToString());

        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
            dg_BD_readers.Visibility = Visibility.Hidden;
            readertxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
        }

        private void AddReaders_Click(object sender, RoutedEventArgs e)
        {
            readers.InsertQuery(pole1.Text, pole2.Text, pole3.Text, pole4.Text, pole5.Text);
            dg_BD_readers.ItemsSource = readers.GetData();
        }

        private void DeleteReaders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            object id = (dg_BD_readers.SelectedItem as DataRowView).Row[0];
            readers.DeleteQuery(Convert.ToInt32(id));
            dg_BD_readers.ItemsSource = readers.GetData();
            }
            catch
            {
                MessageBox.Show("Пашёл на8уй пид...с блyaть");
            }
        }

        private void UpdateReaders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            object id = (dg_BD_readers.SelectedItem as DataRowView).Row[0];
            readers.UpdateQuery(pole1.Text, pole2.Text, pole3.Text, pole4.Text, pole5.Text, Convert.ToInt32(id));
            dg_BD_readers.ItemsSource = readers.GetData();
            }
            catch
            {
                MessageBox.Show("Не трожь внешние ключи!");
            }
        }

        private void dg_BD_readers_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_readers.SelectedItem != null)
            {
                DataRowView row = dg_BD_readers.SelectedItem as DataRowView;
                if (row != null)
                {
                    pole1.Text = row.Row["ReaderSurname"].ToString();
                    pole2.Text = row.Row["ReaderName"].ToString();
                    pole3.Text = row.Row["ReaderMiddleName"].ToString();
                    pole4.Text = row.Row["DateOfBirth"].ToString();
                    pole5.Text = row.Row["Email"].ToString();
                }
            }
        }
    }
}
