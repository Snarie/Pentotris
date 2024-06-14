namespace Pentotris.Interfaces
{
    internal interface IClearSubject
    {
        void AttachClearObserver(IClearObserver observer);
        void DetachClearObserver(IClearObserver observer);
        void ClearNotify(int dropAmount);
    }
}
