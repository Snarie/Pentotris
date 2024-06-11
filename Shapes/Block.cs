namespace Pentotris.Shapes
{
    internal abstract class Block
    {

        protected internal abstract Point[] Position { get; set; }
        protected internal abstract Point StartOffset { get; }
        protected internal abstract int GridSize { get; }
        internal abstract int Id { get; }


        private int rotation;
        private Point offset;

        internal Block()
        {
            offset = new Point(StartOffset.Row, StartOffset.Column);
        }

        internal List<Point> TilePosition()
        {
            List<Point> results = new List<Point>();
            foreach (Point point in Position)
            {
                results.Add(new Point(point.Row + offset.Row, point.Column + offset.Column));
            }
            return results;
        }

        internal void RotateClockwise()
        {
            //rotation = (rotation + 1) % Positions.Length;
            List<Point> newPosition = new();
            foreach (Point point in Position)
            {
                newPosition.Add(new Point(point.Column, GridSize - 1 - point.Row));
            }
            Position = newPosition.ToArray();

        }
        internal void RotateCounterClockwise()
        {
            //rotation = (rotation + Positions.Length - 1) % Positions.Length; 
            List<Point> newPosition = new();
            foreach (Point point in Position)
            {
                newPosition.Add(new Point(GridSize - 1 - point.Column, point.Row));
            }
            Position = newPosition.ToArray();
        }

        internal void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        internal void Reset()
        {
            rotation = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
