using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pentotris.Interfaces;
using Pentotris.Shapes;

namespace Pentotris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IScoreObserver, ILevelObserver
    {


        // Current state of the game
        private State gameState;
        private ScoreBoard scoreBoard;
        private DifficultyManager difficultyManager;
        private readonly ThreadManager threadpool;

        private int DelayDuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            gameState = new(GameCanvas);
            threadpool = new ThreadManager(4);
            scoreBoard = new ScoreBoard("Scoreboard", gameState.GameGrid, threadpool);
            scoreBoard.Attach(this);
            difficultyManager = new DifficultyManager(gameState.GameGrid);
            difficultyManager.Attach(gameState.BlockQueue);
            difficultyManager.Attach(this);
            DelayDuration = 500;
        }

        public void UpdateScore(int score)
        {
            Dispatcher.Invoke(() =>
            {
                ScoreText.Text = $"{difficultyManager.Level} Score: {score}";
            });
        }
        public void LevelUpdate(int level)
        {
            DelayDuration = Math.Max(100, 500 - (20 * level));
        }

        /// <summary>
        /// Draws the entire game state including the grid, current block, and next block.
        /// </summary>
        /// <param name="state">The game state.</param>
        private void Draw(State state)
        {
            state.DrawGrid();
            state.DrawBlock();
            state.DrawNextBlock(NextImage);
            state.DrawHeldBlock(HoldImage);
        }

        /// <summary>
        /// The game loop which continuously updates the game state.
        /// </summary>
        private async Task Loop()
        {
            Draw(gameState);

            threadpool.QueueTask(async () =>
            {
                while (!gameState.Finished)
                {
                    await Task.Delay(DelayDuration);
                    gameState.MoveBlockDown();
                    Dispatcher.Invoke(() => Draw(gameState));
                }

                Dispatcher.Invoke(() =>
                {
                    GameOver.Visibility = Visibility.Visible;
                    FinalScoreText.Text = $"Score: {scoreBoard.Score}";
                    ScoreText.Text = "Score: 0";
                });
            });
            
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
                case Key.C:
                    gameState.HoldBlock();
                    break;
                case Key.Space:
                    gameState.DropBlock();
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
            scoreBoard.Detach(this);
            gameState.GameGrid.Remove();
            gameState = new(GameCanvas);
            scoreBoard = new ScoreBoard("Scoreboard", gameState.GameGrid, threadpool);
            scoreBoard.Attach(this);
            difficultyManager = new DifficultyManager(gameState.GameGrid);
            difficultyManager.Attach(gameState.BlockQueue);
            difficultyManager.Attach(this);
            DelayDuration = 500;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            threadpool.Dispose();
        }
    }
}