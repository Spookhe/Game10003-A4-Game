using System;
using System.Numerics;
using Raylib_cs;

namespace Game10003
{
    public static class GameSounds
    {
        // Asset path for audio files
        private static string assetPath = "../../../assets/audio/";

        // Variables for background music, hit sound, and collect sound
        private static Music backgroundMusic;
        private static Sound collectSound1;
        private static Sound collectSound2;

        // Tracks if music is Playing
        private static bool musicPlaying = false;

        // Loads music and sound assets
        public static void LoadAssets()
        {
            backgroundMusic = Raylib.LoadMusicStream($"{assetPath}PirateSong.mp3"); // Plays BG Music
            collectSound1 = Raylib.LoadSound($"{assetPath}Collect1.mp3"); // Plays Collect Sound#1
            collectSound2 = Raylib.LoadSound($"{assetPath}Collect2.mp3"); // Plays Collect Sound#2
        }

        // Start playing the background music if not already playing
        public static void StartBackgroundMusic()
        {
            if (!musicPlaying)
            {
                Raylib.PlayMusicStream(backgroundMusic);
                musicPlaying = true;
            }
        }

        // Stops background music
        public static void StopBackgroundMusic()
        {
            if (Raylib.IsMusicStreamPlaying(backgroundMusic))
            {
                Raylib.StopMusicStream(backgroundMusic);
                musicPlaying = false;
            }
        }

        // Plays a one-shot collect sound
        public static void PlayCollectSound1()
        {
            Raylib.PlaySound(collectSound1);
        }

        // Plays alternate one-shot collect sound
        public static void PlayCollectSound2()
        {
            Raylib.PlaySound(collectSound2);
        }

        public static void Update()
        {
            // Ensures background music always plays
            Raylib.UpdateMusicStream(backgroundMusic);
        }
    }
}
