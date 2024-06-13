namespace Pentotris.Interfaces
{
    internal interface IClearSubject
    {
        void Attach(IClearObserver observer);
        void Detach(IClearObserver observer);
        void Notify(int dropAmount);
    }
}
