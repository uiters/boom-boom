using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace game3
{
    class Sound
    {
        #region Fields
        private WindowsMediaPlayer player;
        #endregion
        #region Properties
        public WindowsMediaPlayer Player { get => player; set => player = value; }
        #endregion
        #region Methods
        public Sound()
        {
            player = new WindowsMediaPlayer();
        }
        #region Controls
        public void Pause()
        {
            player.controls.pause();
        }
        public void Play()
        {
            player.controls.play();
        }
        public void Stop()
        {
            player.controls.stop();
        }
        public void Repeat()
        {
            player.settings.setMode("loop", true);
        }
        public void RepeatOff()
        {
            player.settings.setMode("loop", false);
        }
        public void Mute()
        {
            player.settings.mute = true;
        }
        public void MuteOff()
        {
            player.settings.mute = false;
        }
        public void SetVolumn(int volumn)
        {
            player.settings.volume = volumn;
        }
        public int GetVolumn()
        {
            return player.settings.volume;
        }
        #endregion
        #region URLs
        public void Menu()
        {
            player.URL = Application.StartupPath + @"\Sound\menu.mp3";
        }
        public void PlayGame()
        {
            player.URL = Application.StartupPath + @"\Sound\playgame.mp3";
        }
        public void NewBomb()
        {
            player.URL = Application.StartupPath + @"\Sound\newbomb.mp3";
        }
        public void Bomb_Bang()
        {
            player.URL = Application.StartupPath + @"\Sound\bomb_bang.mp3";
        }
        public void Boss_Die()
        {
            player.URL = Application.StartupPath + @"\Sound\monster_die.mp3";
        }
        public void Bomber_Die()
        {
            player.URL = Application.StartupPath + @"\Sound\bomber_die.mp3";
        }
        public void Win()
        {
            player.URL = Application.StartupPath + @"\Sound\win.mp3";
        }
        public void Item()
        {
            player.URL = Application.StartupPath + @"\Sound\item.mp3";
        }
        #endregion
        #endregion
    }
}
