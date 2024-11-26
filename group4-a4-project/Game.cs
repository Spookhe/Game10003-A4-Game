using System;
using System.Numerics;
using group4_a4_project;
using Raylib_cs;

namespace Game10003
{
    public class Game
    {
        public static int WindowWidth = 800;
        public static int WindowHeight = 800;

        SceneManager sceneManager;

        // Setup method to load assets and start background music
        public void Setup()
        {
            // Set up the game window
            Window.SetSize(WindowWidth, WindowHeight);
            sceneManager = new SceneManager();
            sceneManager.Setup();
        }

        // Update method to handle game logic, player movement and collision
        public void Update()
        {
           sceneManager.Update();
        }
    }
}
