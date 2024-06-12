namespace Pentotris.Shapes.Pentomino
{
    internal class IPentomino : Block
    {
        private Point[] position = new Point[]
        {
            new(2,0), new(2,1), new(2,2), new(2,3), new(2,4)
        };

        internal override int Id => 11;
        protected internal override Point StartOffset => new(0, 3);
        protected internal override int GridSize => 5;
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
