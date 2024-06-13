using Pentotris.Interfaces;
using Pentotris.Shapes.Tetromino;
using Pentotris.Shapes;
using Pentotris.Shapes.Pentomino;

namespace Pentotris.Factories
{
    internal class PentominoFactory : IBlockFactory
    {
        private readonly Block[] pentominos = new Block[]
        {
            new FPentomino(),
            new GPentomino(),
            new HPentomino(),
            new IPentomino(),
            new JPentomino(),
            new LPentomino(),
            new NPentomino(),
            new PPentomino(),
            new QPentomino(),
            new RPentomino(),
            new SPentomino(),
            new TPentomino(),
            new UPentomino(),
            new VPentomino(),
            new WPentomino(),
            new XPentomino(),
            new YPentomino(),
            new ZPentomino()
        };

        private readonly Random random = new();

        public Block CreateBlock()
        {
            return pentominos[random.Next(pentominos.Length)];
        }
    }
}
