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

        // Tracks if music is Playing
        private static bool musicPlaying = false;

        // Loads music and sound assets
        public static void LoadAssets()
        {
            backgroundMusic = Raylib.LoadMusicStream($"{assetPath}Song.mp3"); // Plays BG Music
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

        public static void Update()
        {
            // Ensures background music always plays
            Raylib.UpdateMusicStream(backgroundMusic);
        }
    }
}
