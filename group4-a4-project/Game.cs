// Include code libraries you need below (use the namespace).
using group4_a4_project;
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
        Player player1 = new Player();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            //720px and 1280px test graphics with player class comment out if need be.
            Window.SetSize(1280, 720);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //I had an issue related to the setup class where when i put the window.clearbackground in setup it caused a strobe affect to happen on screen aswell as the player render class not working properly.
            //when i placed window.clearbackground in update it seemed to fix all of these previously stated issues.
            Window.ClearBackground(Color.White);
            player1.handleInput();
            player1.render(); 
        }
    }
}
