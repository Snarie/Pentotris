using Pentotris.Interfaces;
using System.Windows.Controls;

namespace Pentotris
{
    /// <summary>
    /// Represents a cell in the grid of the Tetris game.
    /// </summary>
    internal class Cell : IGridComponent
    {
        public int Value { get; set; }
        public int Row { get; }
        public int Column { get; }
        public Image Icon { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            Value = 0;
        }
        public void Add(IGridComponent component)
        {
            throw new NotImplementedException();
        }
        public void Remove(IGridComponent component)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGridComponent> GetChildren()
        {
            throw new NotImplementedException();
        }

        public void Operation()
        {
            throw new NotImplementedException();
        }

    }
}
