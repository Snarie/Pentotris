using Pentotris.Interfaces;
using Pentotris.Shapes.Tetromino;
using Pentotris.Shapes;

namespace Pentotris.Factories
{
    internal class TetrominoFactory : IBlockFactory
    {
        private readonly Block[] tetrominos = new Block[]
        {
            new ITetromino(),
            new JTetromino(),
            new LTetromino(),
            new OTetromino(),
            new STetromino(),
            new TTetromino(),
            new ZTetromino(),
        };

        private readonly Random random = new();

        public Block CreateBlock()
        {
            return tetrominos[random.Next(tetrominos.Length)];
        }
    }
}
