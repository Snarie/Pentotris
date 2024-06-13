using Pentotris.Interfaces;
using System.Threading;

namespace Pentotris
{
    internal class DifficultyManager : IClearObserver, ILevelSubject
    {
        /// <summary>
        /// List of classes that are observing upcoming level changes
        /// </summary>
        private readonly List<ILevelObserver> levelObservers = new();
        private int baseDelay;
        private int levelUpScore;
        private readonly double delayDecreaseFactor;
        private readonly int minDelay;
        public int LinesCleared { get; private set; }

        public int Level { get; private set; }
        public int Delay { get; private set; }

        public DifficultyManager(Grid subject)
        {
            Level = 0;
            subject.Attach(this);
        }

        public void Update(int linesCleared)
        {
            LinesCleared += linesCleared;
            if (LinesCleared > Level)
            {
                Level++;
                LinesCleared = 0;
                Notify(Level);
            }
        }

        public void Attach(ILevelObserver observer)
        {
            levelObservers.Add(observer);
        }

        public void Detach(ILevelObserver observer)
        {
            levelObservers.Remove(observer);
        }

        public void Notify(int level)
        {
            foreach(var observer in levelObservers)
            {
                observer.LevelUpdate(level);
            }
        }
    }
}
