using Pentotris.Shapes.Tetromino;
using Pentotris.Shapes;

namespace Pentotris
{
    /// <summary>
    /// Manages the queue of upcoming blocks in the game.
    /// </summary>
    internal class Queue
    {
        /// <summary>
        /// The array of possible tetromino blocks.
        /// </summary>
        private readonly Block[] tetrominos = new Block[]
        {
            new ITetromino(),
            new JTetromino(),
            new LTetromino(),
            new OTetromino(),
            new STetromino(),
            new TTetromino(),
            new ZTetromino()
        };

        /// <summary>
        /// Random number generator for selecting the next block.
        /// </summary>
        private readonly Random random = new();

        /// <summary>
        /// Gets the next block to be used in the game.
        /// </summary>
        internal Block NextBlock { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockQueue"/> class.
        /// </summary>
        internal Queue()
        {
            NextBlock = RandomBlock();
        }

        /// <summary>
        /// Returns a random block from the tetrominos array.
        /// </summary>
        /// <returns>A random <see cref="Block"/>.</returns>
        private Block RandomBlock()
        {
            return tetrominos[random.Next(tetrominos.Length)];
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
    }
}
