namespace Pentotris.Shapes.Tetromino
{
    internal class OTetromino : Block
    {
        private Point[] position = new Point[]
        {
            new(0,0), new(0,1), new(1,0), new(1,1)
        };

        internal override int Id => 4;
        protected internal override Point StartOffset => new(0, 4);
        protected internal override int GridSize => 2;
        protected internal override Point[] Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

    }
}
