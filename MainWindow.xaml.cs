using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pentotris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Sprites/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TileBLue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/TileRed.png", UriKind.Relative))
            //new BitmapImage(new Uri("Sprites/Tile", UriKind.Relative)),
        };
        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Sprites/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Sprites/Block-Z.png", UriKind.Relative))
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}