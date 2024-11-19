using System;
using System.Numerics;

namespace Game10003
{
    public class Game
    {
        private bool playerCollected1 = false;
        private bool playerCollected2 = false;

        public void Setup()
        {
            // Loads background music and one-shots on game start
            GameSounds.LoadAssets();

            // Starts background music
            GameSounds.StartBackgroundMusic();
        }

        public void Update()
        {
            GameSounds.Update(); // Updates sounds from GameAudio.cs

            // Play collect sound when object is collected (object#1)
            if (playerCollected1)
            {
                GameSounds.PlayCollectSound1();
                playerCollected1 = false;
            }

            // Play alternate collect sound when object is collected (object#2)
            if (playerCollected2)
            {
                GameSounds.PlayCollectSound2();
                playerCollected2 = false;
            }
        }

        // When the game is over, Stop the music
        private bool isGameOver = false;

        public void GameOver()
        {
            isGameOver = true;
            GameSounds.StopBackgroundMusic();  // Stop music when game over
        }
    }
}
