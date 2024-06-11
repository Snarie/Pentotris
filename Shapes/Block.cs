namespace Pentotris.Shapes
{
    /// <summary>
    /// Abstract base class representing a block in the game.
    /// </summary>
    internal abstract class Block
    {
        /// <summary>
        /// Array of points representing the block's shape.
        /// </summary>
        protected internal abstract Point[] Position { get; set; }

        /// <summary>
        /// Starting offset to center the block.
        /// </summary>
        protected internal abstract Point StartOffset { get; }

        /// <summary>
        /// Grid size used for rotations.
        /// </summary>
        protected internal abstract int GridSize { get; }

        /// <summary>
        /// Block ID used for identifying the correct sprite and color.
        /// </summary>
        internal abstract int Id { get; }

        /// <summary>
        /// Offset for aligning the block from its center.
        /// </summary>
        private Point offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        internal Block()
        {
            offset = new Point(StartOffset.Row, StartOffset.Column);
        }

        /// <summary>
        /// Gets the positions of the block's tiles on the grid.
        /// </summary>
        /// <returns>A list of points representing the block's tile positions.</returns>
        internal List<Point> TilePosition()
        {
            List<Point> results = new List<Point>();
            foreach (Point point in Position)
            {
                results.Add(new Point(point.Row + offset.Row, point.Column + offset.Column));
            }
            return results;
        }

        /// <summary>
        /// Rotates the block 90 degrees clockwise.
        /// </summary>
        internal void RotateClockwise()
        {
            List<Point> newPosition = new();
            foreach (Point point in Position)
            {
                newPosition.Add(new Point(point.Column, GridSize - 1 - point.Row));
            }
            Position = newPosition.ToArray();

        }

        /// <summary>
        /// Rotates the block 90 degrees counterclockwise.
        /// </summary>
        internal void RotateCounterClockwise()
        {
            List<Point> newPosition = new();
            foreach (Point point in Position)
            {
                newPosition.Add(new Point(GridSize - 1 - point.Column, point.Row));
            }
            Position = newPosition.ToArray();
        }

        /// <summary>
        /// Moves the block by the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">The number of rows to move.</param>
        /// <param name="columns">The number of columns to move.</param>
        internal void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        /// <summary>
        /// Resets the block's position to its starting offset.
        /// </summary>
        internal void Reset()
        {
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
