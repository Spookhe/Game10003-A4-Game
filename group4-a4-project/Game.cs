using System;
using System.Numerics;
using group4_a4_project;
using Raylib_cs;

namespace Game10003
{
    public class Game
    {
        // Define colors
        Color Yellow = new Color(0xFF, 0xFF, 0x00);  // Yellow color for collectable
        Color Blue = new Color(0x00, 0x00, 0xFF);    // Blue color for score text
        Color Gray = new Color(0xA9, 0xA9, 0xA9);    // Gray color for the background
        Color DarkGray = new Color(0x2F, 0x2F, 0x2F); // Dark Gray for game over screen background

        public static int WindowWidth = 800;
        public static int WindowHeight = 800;

        private Player player;
        private float playerSize = 30;
        private Collectable[] collectables;
        private CollisionHandler collisionHandler;
        private Timer gameTimer;
        private bool isGameOver = false;

        public Game()
        {
            // Create player
            player = new Player(playerSize);

            // Create 3 collectables at random positions
            collectables = new Collectable[3];
            System.Random rand = new System.Random();

            for (int i = 0; i < collectables.Length; i++)
            {
                collectables[i] = new Collectable(
                    new Vector2(rand.Next(0, WindowWidth - 50), rand.Next(0, WindowHeight - 50)),
                    new Vector2(50, 50),
                    Color.Yellow
                );
            }

            // Set up collision handler
            collisionHandler = new CollisionHandler(collectables, player, (int)playerSize);

            // Create a timer with 90 seconds (1 minute and 30 seconds)
            gameTimer = new Timer(90);
        }

        // Setup method to load assets and start background music
        public void Setup()
        {
            // Set up the game window
            Window.SetSize(WindowWidth, WindowHeight);

            // Loads background music and one-shots on game start
            GameSounds.LoadAssets();
            GameSounds.StartBackgroundMusic();
        }

        // Update method to handle game logic, player movement and collision
        public void Update()
        {
            // Draw the background
            DrawBackground();

            // Move player and draw player
            player.handleInput();
            player.render();


            // Draw the collectables
            foreach (var collectable in collectables)
            {
                // Set the fill color yellow
                Draw.FillColor = collectable.color;

                // Draws the collectable a square
                Draw.Rectangle(collectable.position.X, collectable.position.Y, collectable.size.X, collectable.size.Y);
            }

            // Update collisions
            collisionHandler.Update();

            // Display score
            Raylib.DrawText($"Score: {collisionHandler.playerScore}", 10, 10, 20, Blue);

            // Update timer and display time
            gameTimer.Update();
            string timeFormatted = FormatTime(gameTimer.RemainingTime);
            Raylib.DrawText($"Time: {timeFormatted}", WindowWidth - 100, 10, 20, Blue); // Creates a blue coloured timer

            // If the game time is 0, the game is over
            if (gameTimer.RemainingTime <= 0 && !isGameOver)
            {
                isGameOver = true;  // If the game is over
                GameOver();         // Stop background music
            }

            // If the game is over, show the game over screen
            if (isGameOver)
            {
                ShowGameOverScreen();
            }

            // Update background music
            GameSounds.Update();
        }

        public void DrawBackground()
        {
            // Draws a gray background
            Draw.FillColor = Gray;
            Draw.Rectangle(0, 0, WindowWidth, WindowHeight);
        }

        // If the game is over, stop the background music
        public void GameOver()
        {
            GameSounds.StopBackgroundMusic();
        }

        // Method to show game over screen with final score
        public void ShowGameOverScreen()
        {
            // Draws a new background for game over screen
            Draw.FillColor = DarkGray;
            Draw.Rectangle(0, 0, WindowWidth, WindowHeight);

            // Display the final score in GameOverScreen
            string finalScoreText = $"Final Score: {collisionHandler.playerScore}";
            Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), finalScoreText, 50, 2);  // Score text scale
            Raylib.DrawText(finalScoreText, (WindowWidth - (int)textSize.X) / 2, (WindowHeight - (int)textSize.Y) / 2, 50, Blue);
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
