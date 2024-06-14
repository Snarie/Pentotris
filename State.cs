using Pentotris.Interfaces;
using Pentotris.Shapes;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Pentotris
{
    /// <summary>
    /// Represents the current state of the game.
    /// </summary>
    internal class State : IBounceSubject, IRotateSubject, IHardDropSubject, ISoftDropSubject, IMoveSubject
    {
        private Block currentBlock;

        private readonly List<IRotateObserver> rotateObservers = new();
        private readonly List<IBounceObserver> bounceObservers = new();
        private readonly List<IHardDropObserver> hardDropObservers = new();
        private readonly List<ISoftDropObserver> softDropObservers = new();
        private readonly List<IMoveObserver> moveObservers = new();

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
        /// Gets the block that is currently saved for later swapping.
        /// </summary>
        public Block HeldBlock { get; private set; }
        /// <summary>
        /// Gets a value indicating whether the block can be hold.
        /// </summary>
        public bool CanHold { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State(Canvas canvas, ThreadManager threadpool)
        {
            GameGrid = new Grid(22, 10, canvas);
            BlockQueue = new Queue(threadpool);
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }
            
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block block = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = block;
            }

            CanHold = false;
        }
        /// <summary>
        /// Checks if the current block fits in the grid.
        /// </summary>
        /// <returns>True if the block fits, otherwise false.</returns>
        private bool BlockFits()
        {
            return !CurrentBlock.TilePosition().Any(point => !GameGrid.Empty(point));
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
            else
            {
                RotateNotify();
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
            else
            {
                RotateNotify();
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
                BounceNotify();
                CurrentBlock.Move(0, 1);
            }
            else
            {
                MoveNotify();
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
                BounceNotify();
                CurrentBlock.Move(0, -1);
            }
            else
            {
                MoveNotify();
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
                GameGrid[point].Value = CurrentBlock.Id;
            }

            GameGrid.ClearRows();

            if (IsGameOver())
            {
                Finished = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
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
            else
            {
                SoftDropNotify();
            }
        }

        private int TileDropDistance(Point point)
        {
            int drop = 0;

            while (GameGrid.Empty(point.Row + drop + 1, point.Column))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;
             
            foreach (Point point in CurrentBlock.TilePosition())
            {
                drop = Math.Min(drop, TileDropDistance(point));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
            HardDropNotify();
        }

        /// <summary>
        /// Draw the grid of blocks on the game grid
        /// </summary>
        public void DrawGrid()
        {
            GameGrid.Draw();
        }

        /// <summary>
        /// Draw the ghost block to see where the block would land at hard drop
        /// </summary>
        public void DrawGhostBlock()
        {
            int dropDistance = BlockDropDistance();

            foreach (Point point in CurrentBlock.TilePosition())
            {
                GameGrid[point.Row + dropDistance, point.Column].Icon.Opacity = 0.25;
                GameGrid[point.Row + dropDistance, point.Column].Icon.Source = GameResources.tileImages[CurrentBlock.Id];
            }
            
        }
        /// <summary>
        /// Draws the current block on the game grid.
        /// </summary>
        public void DrawBlock()
        {
            foreach (Point point in CurrentBlock.TilePosition())
            {
                GameGrid[point.Row, point.Column].Operation(CurrentBlock.Id);
            }
        }
        /// <summary>
        /// Draws the next block in the block queue.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> which holds the next block.</param>
        public void DrawNextBlock(Image image)
        {
            Block next = BlockQueue.NextBlock;
            image.Source = GameResources.blockImages[next.Id];
        }
        public void DrawHeldBlock(Image image)
        {
            if (HeldBlock == null)
            {
                image.Source = GameResources.blockImages[0];
            }
            else
            {
                Block held = HeldBlock;
                image.Source = GameResources.blockImages[held.Id];
            }
        }

        public void AttachBounceObserver(IBounceObserver observer)
        {
            bounceObservers.Add(observer);
        }

        public void DetachBounceObserver(IBounceObserver observer)
        {
            bounceObservers.Remove(observer);
        }

        public void BounceNotify()
        {
            foreach (var observer in bounceObservers)
            {
                observer.BounceUpdate();
            }
        }

        

        public void AttachRotateObserver(IRotateObserver observer)
        {
            rotateObservers.Add(observer);
        }

        public void DetachRotateObserver(IRotateObserver observer)
        {
            rotateObservers.Remove(observer);
        }

        public void RotateNotify()
        {
            foreach (var observer in rotateObservers)
            {
                observer.RotateUpdate();
            }
        }

        public void AttachHardDropObserver(IHardDropObserver observer)
        {
            hardDropObservers.Add(observer);
        }

        public void DetachHardDropObserver(IHardDropObserver observer)
        {
            hardDropObservers.Remove(observer);
        }

        public void HardDropNotify()
        {
            foreach (var observer in hardDropObservers)
            {
                observer.HardDropUpdate();
            }
        }

        public void AttachSoftDropObserver(ISoftDropObserver observer)
        {
            softDropObservers.Add(observer);
        }
        public void DetachSoftropObserver(ISoftDropObserver observer)
        {
            softDropObservers.Remove(observer);
        }
        public void SoftDropNotify()
        {
            foreach (var observer in softDropObservers)
            {
                observer.SoftDropUpdate();
            }
        }

        public void AttachMoveObserver(IMoveObserver observer)
        {
            moveObservers.Add(observer);
        }

        public void DetachMoveObserver(IMoveObserver observer)
        {
            moveObservers.Remove(observer);
        }

        public void MoveNotify()
        {
            foreach (var observer in moveObservers)
            {
                observer.MoveUpdate();
            }
        }
    }
}
