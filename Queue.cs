﻿using Pentotris.Shapes.Tetromino;
using Pentotris.Shapes;
using Pentotris.Shapes.Pentomino;

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
            new ITetromino(), //1
            new JTetromino(), //2
            new LTetromino(), //3
            new OTetromino(), //4
            new STetromino(), //5
            new TTetromino(), //6
            new ZTetromino(), //7
            new FPentomino(), //8
            new GPentomino(), //9
            new HPentomino(), //10
            new IPentomino(), //11
            new JPentomino(), //12
            new LPentomino(), //13
            new NPentomino(), //14
            new PPentomino(), //15
            new QPentomino(), //16
            new RPentomino(), //17
            new SPentomino(), //18
            new TPentomino(), //19
            new UPentomino(), //20
            new VPentomino(), //21
            new WPentomino(), //22
            new XPentomino(), //23
            new YPentomino(), //24
            new ZPentomino()  //25
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
