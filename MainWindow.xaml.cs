using SpotifyWPFSearch.Helpers;
using SpotifyWPFSearch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SpotifyWPFSearch
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            titleBar.MouseLeftButtonDown += (o, e) => DragMove();            

            Task.Run(async () => await SearchHelper.GetTokenAsync());
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                ListArtist.ItemsSource = null;
                return;
            }

            var result = SearchHelper.SearchArtistOrSong(txtSearch.Text);

            if (result == null)
            {
                return;
            }

            var listArtist = new List<SpotifyArtist>();

            foreach (var item in result.artists.items)
            {
                listArtist.Add(new SpotifyArtist()
                {
                    ID = item.id,
                    Image = item.images.Any() ? item.images[0].url : "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png",
                    Name = item.name,
                    Popularity = $"{item.popularity}% popularidad",
                    Followers = $"{item.followers.total.ToString("N")} seguidores"
                });
            }

            ListArtist.ItemsSource = listArtist;
        }

        private void ButtomExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonMinimizeMouseEnter(object sender, MouseEventArgs e)
        {
            ButtonMinimize.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void ButtonExitMouseEnter(object sender, MouseEventArgs e)
        {
            ButtonExit.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
