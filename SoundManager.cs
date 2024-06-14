using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using Pentotris.Interfaces;
using System.Windows.Media;

namespace Pentotris
{
    internal class SoundManager : IClearObserver, IBounceObserver, IRotateObserver, IHardDropObserver, ISoftDropObserver, IMoveObserver
    {

        private readonly ThreadManager threadpool;
        private readonly MediaPlayer player;
        private readonly string baseDirectory;
        private readonly string soundDirectory;
        public SoundManager(Grid grid, State state, ThreadManager threadpool)
        {
            grid.AttachClearObserver(this);
            state.AttachBounceObserver(this);
            state.AttachRotateObserver(this);
            state.AttachHardDropObserver(this);
            state.AttachSoftDropObserver(this);
            state.AttachMoveObserver(this);
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            soundDirectory = Path.Combine(baseDirectory, "Sounds");
            player = new MediaPlayer();
            this.threadpool = threadpool;
        }

        public void PlaySound(string soundFilePath)
        {
            threadpool.QueueTask(() =>
            {

                MediaPlayer localPlayer = new MediaPlayer();
                localPlayer.Open(new Uri(soundFilePath));
                localPlayer.MediaEnded += (s, e) => player.Close();
                localPlayer.Play();
            });


        }

        public void BounceUpdate()
        {
            string path = Path.Combine(soundDirectory, "sidehit.wav");
            PlaySound(path);
        }
        public void Update(int linesCleared)
        {
            string path = Path.Combine(soundDirectory, $"combo_{linesCleared}_power.wav");
            PlaySound(path);
        }
        public void RotateUpdate()
        {
            string path = Path.Combine(soundDirectory, "spin.wav");
            PlaySound(path);
        }
        public void HardDropUpdate()
        {
            string path = Path.Combine(soundDirectory, "harddrop.wav");
            PlaySound(path);
        }
        public void SoftDropUpdate()
        {
            string path = Path.Combine(soundDirectory, "softdrop.wav");
            PlaySound(path);
        }
        public void MoveUpdate()
        {
            string path = Path.Combine(soundDirectory, "move.wav");
            PlaySound(path);
        }
    }
}
