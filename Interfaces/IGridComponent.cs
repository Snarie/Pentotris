namespace Pentotris.Interfaces
{
    internal interface IGridComponent
    {
        void Add(IGridComponent component);
        void Remove(IGridComponent component);
        IGridComponent GetChild(int index);
        void Operation();
    }
}
