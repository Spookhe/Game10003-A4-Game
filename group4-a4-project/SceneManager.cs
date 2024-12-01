using group4_a4_project;
using Raylib_cs;
using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Game10003;

public class SceneManager
{
    // Define colors
    Color Yellow = new Color(0xFF, 0xFF, 0x00);  // Yellow color for collectable
    Color Blue = new Color(0x00, 0x00, 0xFF);    // Blue color for score text
    Color Gray = new Color(0xA9, 0xA9, 0xA9);    // Gray color for the background
    Color DarkGray = new Color(0x2F, 0x2F, 0x2F); // Dark Gray for game over screen background

    private Player player;
    private Collectable[] collectables;
    private CollisionHandler collisionHandler;
    private Timer gameTimer;
    private bool isGameOver;
    private TextHelper textHelper;

    float tempCounter = 0;
    int currentScene = 0;

    public SceneManager()
    {
        // Create player
        player = new Player();

        // Create 3 collectables at random positions
        collectables = new Collectable[3];
        System.Random rand = new System.Random();

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i] = new Collectable(
                new Vector2(rand.Next(0, Window.Width - 50), rand.Next(0, Window.Height - 50)),
                new Vector2(50, 50),
                Color.Yellow
            );
        }

        // Set up collision handler
        collisionHandler = new CollisionHandler(collectables, player);

        // Setup Text Bubble Helper
        textHelper = new TextHelper();

        // Create a timer with 90 seconds (1 minute and 30 seconds)
        gameTimer = new Timer(90);
    }

    public void Setup()
    {
        // Loads background music and one-shots on game start
        GameSounds.LoadAssets();
        GameSounds.StartBackgroundMusic();
    }

    public void Update()
    {
        // Title Screen -----------------------------------------
        if (currentScene == 0)
        {
            TempTitleScreen();
        }
        if (currentScene == 1)
        {
            TempIntroScreen();
        }
        // Main Game Scene --------------------------------------
        else if (currentScene == 2)
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
            Raylib.DrawText($"Time: {timeFormatted}", Window.Width - 100, 10, 20, Blue); // Creates a blue coloured timer

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
    }

    // TODO: Update this screen with title sprite
    void TempTitleScreen()
    {
        
        Draw.FillColor = Color.Blue;
        Draw.Rectangle(0, 0, Window.Width, Window.Height);

        Text.Color = Color.White;
        Text.Draw("PRESS ANY KEY TO CONTINUE", Window.Width/2 - 175, Window.Height/2);
        
        if(AnyKeyIsPressed())
        {
            currentScene = 1;
        }
    }

    void TempIntroScreen()
    {
        Draw.FillColor = Color.Blue;
        Draw.Rectangle(0, 0, Window.Width, Window.Height);

        tempCounter += Time.DeltaTime;

        // Draw a text bubble to explain the goal
        textHelper.TextBubble("bottom", "Your goal is to collect as many items as   possible before time runs out!");

        if (tempCounter > 2)
        {
            Text.Draw("Press any key to continue!", Window.Width / 2 - 175, Window.Height / 2 - 150);
            if (AnyKeyIsPressed())
            {
                currentScene = 2;
            }
        }
    }

    public void DrawBackground()
    {
        // Draws a gray background
        Draw.FillColor = Gray;
        Draw.Rectangle(0, 0, Window.Width, Window.Height);
    }

    // Returns true if any alphabetical key is pressed
    bool AnyKeyIsPressed()
    {
        for (int kbChar = 65; kbChar <= 90; kbChar++)
        {
            if (Raylib.IsKeyPressed((Raylib_cs.KeyboardKey)kbChar))
            {
                // 82 is used for both "R" and android's "menu" key, manually place "R"
                if (kbChar == 82)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                return true;
            }
        }
        return false;
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
        Draw.Rectangle(0, 0, Window.Width, Window.Height);

        // Display the final score in GameOverScreen
        string finalScoreText = $"Final Score: {collisionHandler.playerScore}";
        Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), finalScoreText, 50, 2);  // Score text scale
        Raylib.DrawText(finalScoreText, (Window.Width - (int)textSize.X) / 2, (Window.Height - (int)textSize.Y) / 2, 50, Blue);
    }

    // Format timer (0:00)
    private string FormatTime(int remainingTime)
    {
        int minutes = remainingTime / 60;
        int seconds = remainingTime % 60;
        return $"{minutes}:{seconds:D2}";
    }
}
