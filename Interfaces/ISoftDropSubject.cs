namespace Pentotris.Interfaces
{
    internal interface ISoftDropSubject
    {
        void AttachSoftDropObserver(ISoftDropObserver observer);
        void DetachSoftropObserver(ISoftDropObserver observer);
        void SoftDropNotify();
    }
}
