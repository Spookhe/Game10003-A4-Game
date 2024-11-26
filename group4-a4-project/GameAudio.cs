using Raylib_cs;

namespace Game10003
{
    public static class GameSounds
    {
        // Asset path for audio files
        private static string assetPath = "../../../assets/audio/";

        // Variables for background music, hit sound, collect sound, and collect 1000 sound
        private static Music backgroundMusic;
        private static Sound collectSound;
        private static Sound collect1000Sound;  // New sound for collecting 1000 points

        // Tracks if music is Playing
        private static bool musicPlaying = false;

        // Loads music and sound assets
        public static void LoadAssets()
        {
            backgroundMusic = Raylib.LoadMusicStream($"{assetPath}Pirate.mp3"); // Plays BG Music
            collectSound = Raylib.LoadSound($"{assetPath}Collect.mp3"); // Plays Collect Sound#1
            collect1000Sound = Raylib.LoadSound($"{assetPath}Collect1000.mp3"); // Plays Collect Sound for 1000 score
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
        public static void PlayCollectSound()
        {
            Raylib.PlaySound(collectSound);
        }

        // Plays a one-shot collect 1000 sound
        public static void PlayCollect1000Sound()
        {
            Raylib.PlaySound(collect1000Sound);
        }

        public static void Update()
        {
            // Ensures background music always plays
            Raylib.UpdateMusicStream(backgroundMusic);
        }
    }
}
