using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using practice_2_dataset.DataSet1TableAdapters;

namespace practice_2_dataset
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {

        BookLoansTableAdapter bookloans = new BookLoansTableAdapter();
        public Page4()
        {
            InitializeComponent();
            dg_BD_bookloans.ItemsSource = bookloans.GetData();
        }


        private void AddLoans_Click(object sender, RoutedEventArgs e)
        {
            bookloans.InsertQuery(Convert.ToInt32(pole1.Text), Convert.ToInt32(pole2.Text), pole3.Text, pole4.Text);
            dg_BD_bookloans.ItemsSource = bookloans.GetData();
        }

        private void DeleteLoans_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_bookloans.SelectedItem as DataRowView).Row[0];
                bookloans.DeleteQuery(Convert.ToInt32(id));
                dg_BD_bookloans.ItemsSource = bookloans.GetData();
            }
            catch
            {
                MessageBox.Show("Пашёл на8уй пид...с блyaть");
            }
        }

        private void UpdateLoans_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_bookloans.SelectedItem as DataRowView).Row[0];
                bookloans.UpdateQuery(Convert.ToInt32(pole1.Text), Convert.ToInt32(pole2.Text), pole3.Text, pole4.Text, Convert.ToInt32(id));
                dg_BD_bookloans.ItemsSource = bookloans.GetData();
            }
            catch
            {
                MessageBox.Show("Не трожь внешние ключи!");
            }
        }
    }
}
