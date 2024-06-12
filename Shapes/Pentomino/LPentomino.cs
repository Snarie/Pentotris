namespace Pentotris.Shapes.Pentomino
{
    internal class LPentomino : Block
    {
        private Point[] position = new Point[]
        {
            new(0,1), new(1,1), new(2,1), new(3,1), new(3,2)
        };

        internal override int Id => 13;
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
