namespace Pentatris.Shapes.Tetromino
{
    internal class ITetromino : Block
    {
        private Point[][] positions = new Point[][]
        {
            new Point[] { new(1,0), new(1,1), new(1,2), new(1,3) },
            new Point[] { new(0,2), new(1,2), new(2,2), new(3,2) },
            new Point[] { new(2,0), new(2,1), new(2,2), new(2,3) },
            new Point[] { new(0,1), new(1,1), new(2,1), new(3,1) },
        };

        internal override int Id => 1;
        protected internal override Point StartOffset => new(-1, 3);
        protected internal override Point[][] Positions => positions;

    }
}
