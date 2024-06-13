﻿using Pentotris.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Pentotris
{
    internal class ScoreBoard : IClearObserver, IScoreSubject
    {
        /// <summary>
        /// List of classes that are observing upcoming score changes
        /// </summary>
        private readonly List<IScoreObserver> scoreObservers = new List<IScoreObserver>();

        private string name;
        private Grid subject;
        public int Score { get; private set; }

        public ScoreBoard(string name, Grid subject)
        {
            this.name = name;
            this.subject = subject;
            subject.Attach(this);
        }
        public void Update(int clearedRows)
        {
            switch (clearedRows)
            {
                case 1:
                    Score += 40;
                    break;
                case 2:
                    Score += 100;
                    break;
                case 3:
                    Score += 300;
                    break;
                case 4:
                    Score += 1200;
                    break;
                case 5:
                    Score += 5000;
                    break;
                default:
                    return;
            }
            Notify(Score);
        }

        public void Attach(IScoreObserver observer)
        {
            scoreObservers.Add(observer);
        }
        public void Detach(IScoreObserver observer)
        {
            scoreObservers.Remove(observer);
        }
        public void Notify(int score)
        {
            foreach (var observer in scoreObservers)
            {
                observer.UpdateScore(score);
            }
        }
    }
}
