using System;
using System.Numerics;

namespace Game10003
{
    public class Game
    {
        public void Update()
        {
            GameSounds.Update(); // Updates Sounds from GameSounds.cs
        }

        public void Setup()
        {
            // Loads Music + Sounds when the game starts
            GameSounds.LoadAssets();

            // Starts Music
            GameSounds.StartBackgroundMusic();
        }
    }
}

