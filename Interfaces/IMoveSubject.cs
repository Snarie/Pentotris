namespace Pentotris.Interfaces
{
    internal interface IMoveSubject
    {
        void AttachMoveObserver(IMoveObserver observer);
        void DetachMoveObserver(IMoveObserver observer);
        void MoveNotify();
    }
}
