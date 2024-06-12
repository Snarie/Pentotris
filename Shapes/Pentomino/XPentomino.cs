namespace Pentotris.Shapes.Pentomino
{
    internal class XPentomino : Block
    {
        private Point[] position = new Point[]
        {
            new(0,1), new(1,0), new(1,1), new(1,2), new(2,1)
        };

        internal override int Id => 23;
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
