namespace Pentotris.Interfaces
{
    internal interface IBounceSubject
    {
        void AttachBounceObserver(IBounceObserver observer);
        void DetachBounceObserver(IBounceObserver observer);
        void BounceNotify();
    }
}
