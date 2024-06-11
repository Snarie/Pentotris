using Pentotris.Shapes.Tetromino;
using Pentotris.Shapes;

namespace Pentotris
{
    internal class BlockQueue
    {
        internal BlockQueue()
        {
            NextBlock = RandomBlock();
        }
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

        private readonly Random random = new();

        internal Block NextBlock { get; private set; }

        private Block RandomBlock()
        {
            return tetrominos[random.Next(tetrominos.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            // Make sure we never get the same block 2 tiems in a row
            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
