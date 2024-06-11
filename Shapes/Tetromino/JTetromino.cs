namespace Pentotris.Shapes.Tetromino
{
    internal class JTetromino : Block
    {
        private Point[] position = new Point[]
        {
            new(0,0), new(1,0), new(1,1), new(1,2)
        };

        internal override int Id => 2;
        protected internal override Point StartOffset => new(0, 3);
        protected internal override int GridSize => 3;
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
