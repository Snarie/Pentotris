using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pentotris.Interfaces;
using Pentotris.Shapes;
using Grid = Pentotris.Grid;

namespace Pentotris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Images representing the different types of tiles and blocks
        private readonly ImageSource[] tileImages = new ImageSource[]
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
        private readonly ImageSource[] blockImages = new ImageSource[]
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

        // Current state of the game
        private State gameState = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetupGameCanvas(gameState.GameGrid);
        }

        /// <summary>
        /// Sets up the game canvas by creating image controls for each grid cell.
        /// </summary>
        /// <param name="grid">The game grid.</param>
        /// <returns>A 2D array of image controls.</returns>
        private void SetupGameCanvas(Grid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;
            foreach(Cell cell in grid.GetChildren())
            {
                Image imageControl = new()
                {
                    Width = cellSize,
                    Height = cellSize
                };

                Canvas.SetTop(imageControl, (cell.Row - 2) * cellSize + 10);
                Canvas.SetLeft(imageControl, cell.Column * cellSize);
                GameCanvas.Children.Add(imageControl);
                cell.Icon = imageControl;
            }
        }

        /// <summary>
        /// Draws the game grid.
        /// </summary>
        /// <param name="grid">The game grid.</param>
        private void DrawGrid(Grid grid)
        {
            foreach (Cell cell in grid.GetChildren())
            {
                //imageControls[cell.Row, cell.Column].Source = tileImages[cell.Value];
                cell.Icon.Source = tileImages[cell.Value];
            }
        }

        /// <summary>
        /// Draws the next block in the block queue.
        /// </summary>
        /// <param name="blockQueue">The block queue.</param>
        private void DrawNextBlock(Queue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

        /// <summary>
        /// Draws the current block on the game grid.
        /// </summary>
        /// <param name="block">The current block.</param>
        private void DrawBlock(Block block, Grid grid)
        {
            foreach (Point point in block.TilePosition())
            {
                //imageControls[point.Row, point.Column].Source = tileImages[block.Id];
                grid[point.Row, point.Column].Icon.Source = tileImages[block.Id];
            }
        }

        /// <summary>
        /// Draws the entire game state including the grid, current block, and next block.
        /// </summary>
        /// <param name="state">The game state.</param>
        private void Draw(State state)
        {
            DrawGrid(state.GameGrid);
            DrawBlock(state.CurrentBlock, state.GameGrid);
            DrawNextBlock(state.BlockQueue);
        }

        /// <summary>
        /// The game loop which continuously updates the game state.
        /// </summary>
        private async Task Loop()
        {
            Draw(gameState);

            while (!gameState.Finished)
            {
                await Task.Delay(500);
                gameState.MoveBlockDown();
                Draw(gameState);
            }

            GameOver.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles key down events to control the current block.
        /// </summary>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.Finished)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockClockwise();
                    break;
                case Key.Z:
                    gameState.RotateBlockCounterClockwise();
                    break;
                default:
                    // Return to avoid unnecessary redraw
                    return;
            }

            Draw(gameState);
        }

        /// <summary>
        /// Handles the click event for the start button to restart the game.
        /// </summary>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            gameState = new State();
            GameOver.Visibility = Visibility.Hidden;
            await Loop();
        }

        /// <summary>
        /// Handles the loaded event for the game canvas to start the game loop.
        /// </summary>
        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await Loop();
        }

    }
}