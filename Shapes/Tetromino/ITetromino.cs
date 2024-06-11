namespace Pentotris.Shapes.Tetromino
{
    internal class ITetromino : Block
    {
        private Point[] position = new Point[]
        {
            new(1,0), new(1,1), new(1,2), new(1,3)
        };

        internal override int Id => 1;
        protected internal override Point StartOffset => new(0, 3);
        protected internal override int GridSize => 4;
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
