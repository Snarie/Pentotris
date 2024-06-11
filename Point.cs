namespace Pentotris
{
    internal class Point
    {
        internal int Row { get; set; }
        internal int Column { get; set; }

        internal Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
