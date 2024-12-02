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
        public Vector2 position = new Vector2( 0, 0);

        public float speed = 4f; // Player speed

        // Float size is for player render square size
        float size = 30;

        // Velocity variables
        Vector2 velocity = new Vector2(0, 0);
        // Var x and y velocity 
        float velX = 0;
        float velY = 0;
        //variables for window barriar
        float rightwall;
        float leftwall;
        float upwall;
        float downwall;
        public Vector4 barrier = new Vector4(0,0,800,800);

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
            //intializing positions for walls 
            //these specifically define the start and end of the x coords
            //rightwall = 800;
            //leftwall = 0;
            //and these initialize the upper and lower wall using the start and end of the y window coords
            //upwall = 0;
            //downwall = 800;
            

            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                if (position.Y == barrier.Y)
                {
                    velY = 0; 
                }
                else
                // Y pos for player go down
                velY = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                if (position.X == barrier.X)
                {
                    velX = 0;
                }
                else
                    // X pos for player go down
                    velX = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                if (position.Y == barrier.Z)
                {
                    velY = 0;
                }
                else
                    // Y pos for player go up
                    velY = 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                if (position.X == barrier.W)
                {
                    velX = 0;
                }
                else
                    // X pos for player go up
                    velX = 1;
            }

            // Updates velocity from speed
            velocity = new Vector2(velX * speed, velY * speed);
            
            //if player position is equal to or greater than barrier itll add a value to the position to keep player from progressing

            
        }

        //this is the barrier function inside is a if statement ladder that checks if player position is greater or equal to barrier...
        
    }
      
        //todo list for the most recent branch

        //make sure to change to pascal case 
        //set the window bounderies fix any bugs
        //check in with team to make sure commit functions properly and the window barriers function properly
}
