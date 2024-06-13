﻿namespace Pentotris.Interfaces
{
    internal interface IScoreSubject
    {
        void Attach(IScoreObserver observer);
        void Detach(IScoreObserver observer);
        void Notify(int dropAmount);
    }
}
