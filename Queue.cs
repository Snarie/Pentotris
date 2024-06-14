using Pentotris.Shapes.Tetromino;
using Pentotris.Shapes;
using Pentotris.Shapes.Pentomino;
using Pentotris.Interfaces;
using Pentotris.Factories;

namespace Pentotris
{
    /// <summary>
    /// Manages the queue of upcoming blocks in the game.
    /// </summary>
    internal class Queue : ILevelObserver
    {

        private readonly ThreadManager threadpool;
        private readonly IBlockFactory tetrominoFactory = new TetrominoFactory();
        private readonly IBlockFactory pentominoFactory = new PentominoFactory();


        private int pentominoWeight;

        /// <summary>
        /// Random number generator for selecting the next block.
        /// </summary>
        private readonly Random random = new();

        /// <summary>
        /// Gets the next block to be used in the game.
        /// </summary>
        internal Block NextBlock { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue"/> class.
        /// </summary>
        internal Queue(ThreadManager threadpool)
        {
            this.threadpool = threadpool;
            NextBlock = RandomBlock();
            pentominoWeight = 10;
        }

        /// <summary>
        /// Returns a random block from the tetrominos array.
        /// </summary>
        /// <returns>A random <see cref="Block"/>.</returns>
        private Block RandomBlock()
        {
            // 
            if (random.Next(100) < pentominoWeight)
            {
                return pentominoFactory.CreateBlock();
            }
            else
            {
                return tetrominoFactory.CreateBlock();
            }
        }

        /// <summary>
        /// Gets the current block and updates the queue with a new block.
        /// Ensures the same block is not returned consecutively.
        /// </summary>
        /// <returns>The current <see cref="Block"/>.</returns>
        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do
            {
                NextBlock = RandomBlock();
            }
            // Ensure we don't get the same block consecutively
            while (block.Id == NextBlock.Id);

            return block;
        }

        public void LevelUpdate(int level)
        {
            threadpool.QueueTask(() =>
            {
                // When Weight becomes 100+ it will always spawn a pentomino
                pentominoWeight = level * 5 + 10;
            });

        }
    }
}
