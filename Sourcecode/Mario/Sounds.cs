using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public static class Sounds
    {
        static string path = System.IO.Directory.GetCurrentDirectory() + @"/Sounds";
        static System.Media.SoundPlayer soundThemeSong = new System.Media.SoundPlayer(path + @"/theme_song.wav");

        public static void PlayThemesong()
        {
            soundThemeSong.PlayLooping();
        }

        public static void StopThemesong()
        {
            soundThemeSong.Stop();
        }

        public static void playJump()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(path + @"/jump.wav");
            sound.Play();
        }

        public static void GameOver(bool sync = true)
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(path + @"/game_over.wav");

            if (sync)
            {
                sound.PlaySync();
            }
            else
            {
                sound.Play();
            }
        }

        public static void MarioDie()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(path + @"/mario_die.wav");
            sound.PlaySync();
        }

        public static void Clear()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(path + @"/clear.wav");
            sound.PlaySync();
        }

        public static void TimeWarning()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(path + @"/time_warning.wav");
            sound.Play();
        }
    }
}
