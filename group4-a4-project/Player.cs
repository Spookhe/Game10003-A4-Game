using Game10003;
using System;
using System.Numerics;

namespace group4_a4_project
{
    public class Player
    {
        // Declared variables 
        // Vector2 position is for rendering the player square visual, where it spawns in.

        //public Vector2 position = new Vector2(600, 600);
        public Vector2 position = new Vector2( playerx, playery);

        public float speed = 4f; // Player speed

        // Float size is for player render square size
        float size = 30;

        // Velocity variables
        Vector2 velocity = new Vector2(0, 0);
        // Var x and y velocity 
        float velX = 0;
        float velY = 0;
        //variables for player position and barriar
        private static float playerx;
        private static float playery;
        private static float playerxneg = playerx + 30;
        private static float playeryneg = playery + 30;

        // Rendering player sprite (it's a square for now)
        public void render()
        {
            position = velocity + position;
            Draw.FillColor = Color.Red;
            Draw.Square(position, size);
        }

        // Handle input function is for checking where the player is moving and applying that velocity to their movement
        public void handleInput()
        {
            // Resets velocity x and y so that the key won't be perpetually moving
            velX = 0;
            velY = 0;

            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                // Y pos for player go down
                velY = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                // X pos for player go down
                velX = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                // Y pos for player go up
                velY = 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                // X pos for player go up
                velX = 1;
            }

            // Updates velocity from speed
            velocity = new Vector2(velX * speed, velY * speed);
        }

        //this is the barrier function inside is a if statement ladder that checks if player position is greater or equal to barrier...
        public void Barrier()
        {
            //if player position is equal to or greater than barrier itll add a value to the position to keep player from progressing
            if (playerx >= 800)
            {


            }
            if (playery >= 800)
            {


            }
            //player x & y neg is just the other side of the player render...
            //since xy pos is top left corner when rendering player i made the other side of the player square to make sure the barrier sees player as a square not a dot.
            //if there is an easier way ill make changes and commit..
            if(playerxneg >= 800)
            {

            }
            if(playerxneg >= 800)
            {

            }
        }

        

        //todo list for the most recent branch

        //make sure to change to pascal case 
        //set the window bounderies fix any bugs
        //check in with team to make sure commit functions properly and the window barriers function properly
        
    }
}
