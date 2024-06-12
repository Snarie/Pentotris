namespace Pentotris.Shapes.Tetromino
{
    internal class FPentomino : Block
    {
        private Point[] position = new Point[]
        {
            new(0,1), new(1,0), new(1,1), new(1,2), new(2,0)
        };

        internal override int Id => 8;
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
