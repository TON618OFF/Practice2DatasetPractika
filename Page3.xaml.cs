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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {

        GenresTableAdapter genres = new GenresTableAdapter();
        public Page3()
        {
            InitializeComponent();
            dg_BD_genres.ItemsSource = genres.GetData();
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page4();
            genrestxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
        }


        private void AddGenres_Click(object sender, RoutedEventArgs e)
        {
            genres.InsertQuery(pole1.Text);
            dg_BD_genres.ItemsSource = genres.GetData();
        }

        private void DeleteGenres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_genres.SelectedItem as DataRowView).Row[0];
                genres.DeleteQuery(Convert.ToInt32(id));
                dg_BD_genres.ItemsSource = genres.GetData();
            }
            catch
            {
                MessageBox.Show("Пашёл на8уй пид...с блyaть");
            }
        }

        private void UpdateGenres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (dg_BD_genres.SelectedItem as DataRowView).Row[0];
                genres.UpdateQuery(pole1.Text, Convert.ToInt32(id));
                dg_BD_genres.ItemsSource = genres.GetData();
            }
            catch
            {
                MessageBox.Show("Не трожь внешние ключи!");
            }
        }

        private void dg_BD_genres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_genres.SelectedItem != null)
            {
                DataRowView row = dg_BD_genres.SelectedItem as DataRowView;
                if (row != null)
                {
                    pole1.Text = row.Row["Genre"].ToString();
                }
            }
        }
    }
}
