namespace Pentotris.Interfaces
{
    internal interface ILevelSubject
    {
        void Attach(ILevelObserver observer);
        void Detach(ILevelObserver observer);
        void Notify(int level);
    }
}
