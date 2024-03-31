using System;
using System.Collections.Generic;
using System.Data;
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
using practice_2_dataset.DataSet1TableAdapters;

namespace practice_2_dataset
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        AuthorsTableAdapter authors = new AuthorsTableAdapter();

        public Page2()
        {
            InitializeComponent();
            dg_BD_authors.ItemsSource = authors.GetData();
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page3();
            authorstxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
        }
        private void AddAuthors_Click(object sender, RoutedEventArgs e)
        {
            authors.InsertQuery(pole1.Text, pole2.Text, pole3.Text);
            dg_BD_authors.ItemsSource = authors.GetData();
        }

        private void DeleteAuthors_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            object id = (dg_BD_authors.SelectedItem as DataRowView).Row[0];
            authors.DeleteQuery(Convert.ToInt32(id));
            dg_BD_authors.ItemsSource = authors.GetData();
            }
            catch
            {
                MessageBox.Show("Пашёл на8уй пид...с блyaть");
            }
        }

        private void UpdateAuthors_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_authors.SelectedItem as DataRowView).Row[0];
                authors.UpdateQuery(pole1.Text, pole2.Text, pole3.Text, Convert.ToInt32(id));
                dg_BD_authors.ItemsSource = authors.GetData();
            }
            catch
            {
                MessageBox.Show("Не трожь внешние ключи!");
            }
        }
    }
}
