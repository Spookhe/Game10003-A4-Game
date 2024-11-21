// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        TextHelper textHelper;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("teamproj");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
            textHelper = new TextHelper();
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Gray);
            textHelper.TextBubble("bottom", "Test with more than 42 characters, hopefully this works lmao");
            
        }
    }
}
