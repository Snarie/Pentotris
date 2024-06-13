using Pentotris.Interfaces;
using System.Windows.Controls;
using System.Windows.Media;

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
        public IEnumerable<IGridComponent> GetChildren()
        {
            throw new NotImplementedException();
        }
        public void Operation(int value)
        {
            Icon.Source = GameResources.tileImages[value];
        }
        public void Draw()
        {
            Icon.Source = GameResources.tileImages[Value];
        }
    }
}
