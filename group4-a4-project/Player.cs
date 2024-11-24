using Game10003;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace group4_a4_project
{
    internal class Player
    {
        //declared variables 
        Vector2 position = new Vector2(600,600);
        float size = 30;
        Vector2 velocity = new Vector2(0,0);
        //make a proper score system
        int score;

        void render()
        {
            position = velocity + position;
            Draw.Square(position, size);
        }
        //Im actively in the prosess of making the player render move in the derections i want it to move

        void handleInput()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                //y pos for player go down
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                //x pos for player go down
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                //y pos for player go up
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                //x pos for player go up
            }
        }


        //everything below is just some stuff iv commented out for the sake of keeping everything running properly.Aswell as a kinda todo list.

        //set vector2 variables for player position

        // KeyboardInput

        //if (Input.IsKeyboardKeyDown(KeyboardInput.Space))

        //velocity 
        //window size


    }
}
