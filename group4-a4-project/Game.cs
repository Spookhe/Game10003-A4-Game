using System;
using System.Numerics;
using Raylib_cs;

namespace Game10003
{
    public class Game
    {
        Color Yellow = new Color(0xFF, 0xFF, 0x00);

        public static int WindowWidth = 800;
        public static int WindowHeight = 800;

        private Collectable[] collectables;

        public Game()
        {
            // Create 3 collectable squares at random positions
            collectables = new Collectable[3];
            System.Random rand = new System.Random();

            for (int i = 0; i < collectables.Length; i++)
            {
                collectables[i] = new Collectable(
                    new Vector2(rand.Next(0, WindowWidth - 50), rand.Next(0, WindowHeight - 50)),  // Random position
                    new Vector2(50, 50),  // Size of each collectable
                    Color.Yellow
                );
            }
        }

        public void Setup()
        {
        }

        public void Update()
        {
            // Draw each collectable as a yellow square
            foreach (var collectable in collectables)
            {
                // Draw each collectable with its position and size
                Raylib.DrawRectangleV(collectable.position, collectable.size, collectable.color);
            }

            //TODO: Add Updates for Sounds, Collision and Score
        }
    }
}
