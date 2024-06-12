namespace Pentotris.Shapes.Pentomino
{
    internal class QPentomino : Block
    {
        private Point[] position = new Point[]
        {
            new(0,0), new(0,1), new(1,0), new(1,1), new(1,2)
        };

        internal override int Id => 9;
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
