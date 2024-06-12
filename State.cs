using Pentotris.Shapes;

namespace Pentotris
{
    /// <summary>
    /// Represents the current state of the game.
    /// </summary>
    internal class State
    {
        private Block currentBlock;

        /// <summary>
        /// Gets or sets the current block. Resets the block position upon setting.
        /// </summary>
        internal Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        /// <summary>
        /// Gets the game grid.
        /// </summary>
        internal Grid GameGrid { get; }

        /// <summary>
        /// Gets the block queue.
        /// </summary>
        internal Queue BlockQueue { get; }

        /// <summary>
        /// Gets a value indicating whether the game is finished.
        /// </summary>
        internal bool Finished { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State()
        {
            GameGrid = new Grid(22, 10);
            BlockQueue = new Queue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        /// <summary>
        /// Checks if the current block fits in the grid.
        /// </summary>
        /// <returns>True if the block fits, otherwise false.</returns>
        private bool BlockFits()
        {
            //return !CurrentBlock.TilePosition().Any(point => !GameGrid.Empty(point));
            foreach (Point point in CurrentBlock.TilePosition())
            {
                if (!GameGrid.Empty(point))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Rotates the current block clockwise if it fits.
        /// </summary>
        internal void RotateBlockClockwise()
        {
            CurrentBlock.RotateClockwise();

            if (!BlockFits())
            {
                CurrentBlock.RotateCounterClockwise();
            }
        }

        /// <summary>
        /// Rotates the current block counterclockwise if it fits.
        /// </summary>
        internal void RotateBlockCounterClockwise()
        {
            CurrentBlock.RotateCounterClockwise();

            if (!BlockFits())
            {
                CurrentBlock.RotateClockwise();
            }
        }

        /// <summary>
        /// Moves the current block to the left if it fits.
        /// </summary>
        internal void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        /// <summary>
        /// Moves the current block to the right if it fits.
        /// </summary>
        internal void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        /// <returns>True if the game is over, otherwise false.</returns>
        private bool IsGameOver()
        {
            // Check if either of the invisble rows are not emtpy
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        /// <summary>
        /// Places the current block on the grid and updates the game state.
        /// </summary>
        private void PlaceBlock()
        {
            foreach (Point point in CurrentBlock.TilePosition())
            {
                GameGrid[point] = CurrentBlock.Id;
            }

            GameGrid.ClearRows();

            if (IsGameOver())
            {
                Finished = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        /// <summary>
        /// Moves the current block down if it fits; places the block otherwise.
        /// </summary>
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
    }
}
