namespace Pentotris.Interfaces
{
    internal interface IHardDropSubject
    {
        void AttachHardDropObserver(IHardDropObserver observer);
        void DetachHardDropObserver(IHardDropObserver observer);
        void HardDropNotify();
    }
}
