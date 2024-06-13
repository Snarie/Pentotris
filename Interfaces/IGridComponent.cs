namespace Pentotris.Interfaces
{
    internal interface IGridComponent
    {
        //void Add(IGridComponent component);
        //void Remove(IGridComponent component);
        IEnumerable<IGridComponent> GetChildren();
        void Operation();
    }
}
