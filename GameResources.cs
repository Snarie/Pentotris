using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Pentotris
{
    internal static class GameResources
    {
        // Images representing the different types of tiles and blocks
        public static ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Sprites/TileEmpty.png", UriKind.Relative)), //0
            new BitmapImage(new Uri("Sprites/TetroTiles/Cyan.png", UriKind.Relative)), //1
            new BitmapImage(new Uri("Sprites/TetroTiles/BLue.png", UriKind.Relative)), //2
            new BitmapImage(new Uri("Sprites/TetroTiles/Orange.png", UriKind.Relative)), //3
            new BitmapImage(new Uri("Sprites/TetroTiles/Yellow.png", UriKind.Relative)), //4
            new BitmapImage(new Uri("Sprites/TetroTiles/Green.png", UriKind.Relative)), //5
            new BitmapImage(new Uri("Sprites/TetroTiles/Purple.png", UriKind.Relative)), //6
            new BitmapImage(new Uri("Sprites/TetroTiles/Red.png", UriKind.Relative)), //7
            new BitmapImage(new Uri("Sprites/PentoTiles/Red.png", UriKind.Relative)), //8
            new BitmapImage(new Uri("Sprites/PentoTiles/Red.png", UriKind.Relative)), //9
            new BitmapImage(new Uri("Sprites/PentoTiles/Yellow.png", UriKind.Relative)), //10
            new BitmapImage(new Uri("Sprites/PentoTiles/Magenta.png", UriKind.Relative)), //11
            new BitmapImage(new Uri("Sprites/PentoTiles/Green.png", UriKind.Relative)), //12
            new BitmapImage(new Uri("Sprites/PentoTiles/Green.png", UriKind.Relative)), //13
            new BitmapImage(new Uri("Sprites/PentoTiles/Blue.png", UriKind.Relative)), //14
            new BitmapImage(new Uri("Sprites/PentoTiles/Orange.png", UriKind.Relative)), //15
            new BitmapImage(new Uri("Sprites/PentoTiles/Orange.png", UriKind.Relative)), //16
            new BitmapImage(new Uri("Sprites/PentoTiles/Neon.png", UriKind.Relative)), //17
            new BitmapImage(new Uri("Sprites/PentoTiles/Blue.png", UriKind.Relative)), //18
            new BitmapImage(new Uri("Sprites/PentoTiles/Purple.png", UriKind.Relative)), //19
            new BitmapImage(new Uri("Sprites/PentoTiles/Purple.png", UriKind.Relative)), //20
            new BitmapImage(new Uri("Sprites/PentoTiles/Magenta.png", UriKind.Relative)), //21
            new BitmapImage(new Uri("Sprites/PentoTiles/Cyan.png", UriKind.Relative)), //22
            new BitmapImage(new Uri("Sprites/PentoTiles/Cyan.png", UriKind.Relative)), //23
            new BitmapImage(new Uri("Sprites/PentoTiles/Yellow.png", UriKind.Relative)), //24
            new BitmapImage(new Uri("Sprites/PentoTiles/Neon.png", UriKind.Relative)), //25
        }; 
        public static ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Sprites/Block-Empty.png", UriKind.Relative)), //0
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-I.png", UriKind.Relative)), //1
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-J.png", UriKind.Relative)), //2
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-L.png", UriKind.Relative)), //3
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-O.png", UriKind.Relative)), //4
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-S.png", UriKind.Relative)), //5
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-T.png", UriKind.Relative)), //6
            new BitmapImage(new Uri("Sprites/Tetrominos/Block-Z.png", UriKind.Relative)), //7
            new BitmapImage(new Uri("Sprites/Pentominos/Block-F.png", UriKind.Relative)), //8
            new BitmapImage(new Uri("Sprites/Pentominos/Block-G.png", UriKind.Relative)), //9
            new BitmapImage(new Uri("Sprites/Pentominos/Block-H.png", UriKind.Relative)), //10
            new BitmapImage(new Uri("Sprites/Pentominos/Block-I.png", UriKind.Relative)), //11
            new BitmapImage(new Uri("Sprites/Pentominos/Block-J.png", UriKind.Relative)), //12
            new BitmapImage(new Uri("Sprites/Pentominos/Block-L.png", UriKind.Relative)), //13
            new BitmapImage(new Uri("Sprites/Pentominos/Block-N.png", UriKind.Relative)), //14
            new BitmapImage(new Uri("Sprites/Pentominos/Block-P.png", UriKind.Relative)), //15
            new BitmapImage(new Uri("Sprites/Pentominos/Block-Q.png", UriKind.Relative)), //16
            new BitmapImage(new Uri("Sprites/Pentominos/Block-R.png", UriKind.Relative)), //17
            new BitmapImage(new Uri("Sprites/Pentominos/Block-S.png", UriKind.Relative)), //18
            new BitmapImage(new Uri("Sprites/Pentominos/Block-T.png", UriKind.Relative)), //19
            new BitmapImage(new Uri("Sprites/Pentominos/Block-U.png", UriKind.Relative)), //20
            new BitmapImage(new Uri("Sprites/Pentominos/Block-V.png", UriKind.Relative)), //21
            new BitmapImage(new Uri("Sprites/Pentominos/Block-W.png", UriKind.Relative)), //22
            new BitmapImage(new Uri("Sprites/Pentominos/Block-X.png", UriKind.Relative)), //23
            new BitmapImage(new Uri("Sprites/Pentominos/Block-Y.png", UriKind.Relative)), //24
            new BitmapImage(new Uri("Sprites/Pentominos/Block-Z.png", UriKind.Relative)), //25
        };
    }
}
