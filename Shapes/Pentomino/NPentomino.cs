namespace Pentotris.Shapes.Pentomino
{
    internal class NPentomino : Block
    {
        private Point[] position = new Point[]
        {
            new(1,2), new(1,3), new(2,0), new(2,1), new(2,2)
        };

        internal override int Id => 9;
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
