﻿namespace Pentatris.Shapes.Tetromino
{
    internal class ZTetromino : Block
    {
        private Point[][] positions = new Point[][]
        {
            new Point[] { new(0,0), new(0,1), new(1,1), new(1,2) },
            new Point[] { new(0,2), new(1,1), new(1,2), new(2,1) },
            new Point[] { new(1,0), new(1,1), new(2,1), new(2,2) },
            new Point[] { new(0,1), new(1,0), new(1,1), new(2,0) },
        };

        internal override int Id => 7;
        protected internal override Point StartOffset => new(0, 3);
        protected internal override Point[][] Positions => positions;

    }
}
