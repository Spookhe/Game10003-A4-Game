using Game10003;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace group4_a4_project
{
    internal class Player
    {
        //declared variables 
        //vector2 position is for rendering the player square visual, where it spawns in.
        public Vector2 position = new Vector2(600,600);
        //float size is for player render square size

        float size = 30;

        //velocity variables
        Vector2 velocity = new Vector2(0,0);
        //var x and y velocity 
        float velX = 0;
        float velY = 0;

        //shift around velocity xy to put it into vector2 for aethetics

        //make a proper score system. (this will be integrated later once iv spoken with my team)
        //team members wanted me to make a few things public so ill do that here... (player positiom & score)...
        public int score;

        //rendering player sprite (its a square for now)
        public void render()
        {
            position = velocity + position;
            Draw.FillColor = Color.Red;
            Draw.Square(position, size);
        }

        //handle imput function is for checking where the player is moving and applying that velocity to their movement
        public void handleInput()
        {
            //resets velocity x and y so that they key wont be perpetually moving
            velX = 0;
            velY = 0;

            //you can change the velocity variable values below to adjust to how the game plays.
            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                //y pos for player go down
                velY = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                //x pos for player go down
                velX = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                //y pos for player go up
                velY = 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                //x pos for player go up
                velX = 1;
            }

            //this allows by velocity variables xy to be defined as velx and vely.
            velocity = new Vector2(velX, velY);

        }


        //everything below is just some stuff iv commented out for the sake of keeping everything running properly.Aswell as a kinda todo list.
        //everything has been completed so far... @me if there are any further issues

        //add a score counter after speaking with team memebers.
        //add player spawning in after intro screen is turned off.
        //add vector2 position of player public function (this need is null now from my understanding making the position vector2 variable public already fulfilled the need for this)
        //bug (non critical) there are no borders set to the game player can leave map and disapear off screen indefinitly... (requires fix laterrrr)
    }
}
