namespace Pentatris.Shapes.Tetromino
{
    internal class TTetromino : Block
    {
        private Point[][] positions = new Point[][]
        {
            new Point[] { new(0,1), new(1,0), new(1,1), new(1,2) },
            new Point[] { new(0,1), new(1,1), new(1,2), new(2,1) },
            new Point[] { new(1,0), new(1,1), new(1,2), new(2,1) },
            new Point[] { new(0,1), new(1,0), new(1,1), new(2,1) },
        };

        internal override int Id => 6;
        protected internal override Point StartOffset => new(0, 3);
        protected internal override Point[][] Positions => positions;

    }
}
