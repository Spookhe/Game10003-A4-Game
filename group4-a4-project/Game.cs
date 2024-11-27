using System;
using System.Numerics;
using Raylib_cs;

namespace Game10003
{
    public class Game
    {
        Color Blue = new Color(0x00, 0x00, 0xFF);    // Blue color for score text

        public static int WindowWidth = 800;
        public static int WindowHeight = 800;

        private Timer gameTimer;


        gameTimer = new Timer(90);
    }

    public void Setup()
    {
    }

    public void Update()
    {

        // Update timer and display time
        gameTimer.Update();
        string timeFormatted = FormatTime(gameTimer.RemainingTime);
        Raylib.DrawText($"Time: {timeFormatted}", WindowWidth - 100, 10, 20, Blue); // Creates a blue coloured timer

        // If the game time is 0, the game is over
        if (gameTimer.RemainingTime <= 0 && !isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
        // Format timer (0:00)
        private string FormatTime(int remainingTime)
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            return $"{minutes}:{seconds:D2}";
        }
    }
}
