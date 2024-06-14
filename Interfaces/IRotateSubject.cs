namespace Pentotris.Interfaces
{
    internal interface IRotateSubject
    {
        void AttachRotateObserver(IRotateObserver observer);
        void DetachRotateObserver(IRotateObserver observer);
        void RotateNotify();
    }
}
