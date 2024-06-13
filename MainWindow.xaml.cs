﻿using System.Windows;
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
    public partial class MainWindow : Window, IScoreObserver
    {


        // Current state of the game
        private State gameState;
        private ScoreBoard scoreBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            gameState = new(GameCanvas);
            scoreBoard = new ScoreBoard("Scoreboard", gameState.GameGrid);
            scoreBoard.Attach(this);
        }

        public void UpdateScore(int score)
        {
            ScoreText.Text = $"Score: {score}";
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
            FinalScoreText.Text = $"Score: {scoreBoard.Score}";
            ScoreText.Text = "Score: 0";
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
            scoreBoard.Detach(this);
            gameState.GameGrid.Remove();
            gameState = new(GameCanvas);
            scoreBoard = new ScoreBoard("Scoreboard", gameState.GameGrid);
            scoreBoard.Attach(this);
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