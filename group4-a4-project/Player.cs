using Game10003;
using System;
using System.Numerics;

namespace group4_a4_project
{
    public class Player
    {
        // Declared variables 
        // Vector2 position is for rendering the player square visual, where it spawns in.
        public Vector2 position = new Vector2(600, 600);

        public float speed = 4f; // Player speed

        // Float size is for player render square size
        public float size = 90;

        // Velocity variables
        Vector2 velocity = new Vector2(0, 0);
        // Var x and y velocity 
        float velX = 0;
        float velY = 0;

        Texture2D playerSprite;

        // Rendering player sprite (it's a square for now)

        public Player()
        {
            playerSprite = Graphics.LoadTexture("../../../assets/sprites/SS Cantata Fixed Right.png");
        }

        public void render()
        {
            position = velocity + position;
            Draw.FillColor = Color.Red;

            Graphics.Draw(playerSprite, position.X, position.Y);
            //Draw.Square(position, size);
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
                // X pos for player go left
                velX = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                // Y pos for player go down
                velY = 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                // X pos for player go right
                velX = 1;
            }

            // Updates velocity from speed
            velocity = new Vector2(velX * speed, velY * speed);
        }
    }
}
