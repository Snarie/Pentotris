using System.Windows.Media;

namespace Pentotris.Interfaces
{
    internal interface IGridComponent
    {
        /// <summary>
        /// Gives a list of all children of this class
        /// </summary>
        /// <returns>The <see cref="IGridComponent"/> that are children of this <see cref="IGridComponent"/></returns>
        IEnumerable<IGridComponent> GetChildren();
        void Operation(int value);
        void Draw();
    }
}
