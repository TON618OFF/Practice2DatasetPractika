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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        BooksTableAdapter books = new BooksTableAdapter();

        public Page1()
        {
            InitializeComponent();
            dg_BD_books.ItemsSource = books.GetData();
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
            bookstxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            books.InsertQuery(pole1.Text, Convert.ToInt32(pole2.Text), Convert.ToInt32(pole3.Text), pole4.Text);
            dg_BD_books.ItemsSource = books.GetData();
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_books.SelectedItem as DataRowView).Row[0];
                books.DeleteQuery(Convert.ToInt32(id));
                dg_BD_books.ItemsSource = books.GetData();
            }
            catch
            {
                MessageBox.Show("Пашёл на8уй пид...с блyaть");
            }
        }

        private void UpdateBooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_books.SelectedItem as DataRowView).Row[0];
                books.UpdateQuery(pole1.Text, Convert.ToInt32(pole2.Text), Convert.ToInt32(pole3.Text), pole4.Text, Convert.ToInt32(id));
                dg_BD_books.ItemsSource = books.GetData();
            }
            catch
            {
                MessageBox.Show("Не трожь внешние ключи!");
            }
        }
    }
}
