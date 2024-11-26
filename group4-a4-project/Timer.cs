using System;
using System.Numerics;
using Raylib_cs;

namespace Game10003
{
    public class Timer
    {
        private int totalTime;          // Total time of the game (time of the song)
        private int remainingTime;      // Time remaining in seconds
        private float elapsedTime = 0f;

        // Constructor takes the total time for the game in seconds
        public Timer(int totalTimeInSeconds)
        {
            totalTime = totalTimeInSeconds;
            remainingTime = totalTimeInSeconds;
        }

        public void Update()
        {
            // Time passed per frame (seconds)
            elapsedTime += Raylib.GetFrameTime();

            // If at least 1 second has passed, decrease remaining time
            if (elapsedTime >= 1f)
            {
                remainingTime--;
                elapsedTime -= 1f; // Subtract 1 second from elapsedtime
            }
        }

        // Gets the time remainder
        public int RemainingTime
        {
            get { return remainingTime; }
        }
    }
}
