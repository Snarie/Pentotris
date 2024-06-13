using Pentotris.Interfaces;

namespace Pentotris
{
    /// <summary>
    /// Represents the grid of the Tetris game.
    /// </summary>
    internal class Grid : IGridComponent
    {
        /// <summary>
        /// The 2D array representing the grid.
        /// </summary>
        private readonly Cell[,] cells;

        /// <summary>
        /// Gets the number of rows in the grid.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Gets the number of columns in the grid.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Accessor for grid elements by row and column.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>The value at the specified position in the grid.</returns>
        public Cell this[int row, int column]
        {
            get => cells[row, column];
            set => cells[row, column] = value;
        }

        /// <summary>
        /// Accessor for grid elements by a Point.
        /// </summary>
        /// <param name="point">The point representing the position.</param>
        /// <returns>The value at the specified position in the grid.</returns>
        public Cell this[Point point]
        {
            get => cells[point.Row, point.Column];
            set => cells[point.Row, point.Column] = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class with specified rows and columns.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            //grid = new int[rows, columns];
            cells = new Cell[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    cells[row, column] = new Cell(row, column);
                }
            }
        }

        /// <summary>
        /// Checks if the specified position is inside the grid.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>True if the position is inside the grid, otherwise false.</returns>
        public bool Inside(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        /// <summary>
        /// Checks if the specified position is empty.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>True if the position is empty, otherwise false.</returns>
        public bool Empty(int row, int column)
        {
            return Inside(row, column) && cells[row, column].Value == 0;
        }

        /// <summary>
        /// Checks if the specified position is empty.
        /// </summary>
        /// <param name="point">The point representing the position.</param>
        /// <returns>True if the position is empty, otherwise false.</returns>
        public bool Empty(Point point)
        {
            return Empty(point.Row, point.Column);
        }

        /// <summary>
        /// Checks if the specified row is full.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <returns>True if the row is full, otherwise false.</returns>
        public bool IsRowFull(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (Empty(row, column)) return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the specified row is empty.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <returns>True if the row is empty, otherwise false.</returns>
        public bool IsRowEmpty(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (!Empty(row, column)) return false;
            }
            return true;
        }

        /// <summary>
        /// Clears all cells in the specified row.
        /// </summary>
        /// <param name="row">The row index.</param>
        public void ClearRow(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                cells[row, column].Value = 0;
            }
        }

        /// <summary>
        /// Moves the specified row by a certain number of rows.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="rowAmount">The number of rows to move.</param>
        public void MoveRow(int row, int rowAmount)
        {
            for (int column = 0; column < Columns; column++)
            {
                cells[row + rowAmount, column].Value = cells[row, column].Value;
                cells[row, column].Value = 0;
            }
        }

        /// <summary>
        /// Clears all full rows and moves down the rows above.
        /// </summary>
        /// <returns>The number of cleared rows.</returns>
        public int ClearRows()
        {
            int dropAmount = 0;

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    dropAmount++;
                }
                else if (dropAmount > 0)
                {
                    MoveRow(row, dropAmount);
                }
            }
            return dropAmount;
        }

        public IEnumerable<IGridComponent> GetChildren()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    yield return cells[row, column];
                }
            }
        }
        public void Operation()
        {
            throw new NotImplementedException();
        }
    }
}
