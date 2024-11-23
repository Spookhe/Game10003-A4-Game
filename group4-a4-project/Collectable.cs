using System;
using System.Numerics;

namespace Game10003
{
    public class Collectable
    {
        public Vector2 position;
        public Vector2 size;
        public Color color;

        // Constructor for collectable color, size, and positioning
        public Collectable(Vector2 position, Vector2 size, Color color)
        {
            this.position = position;
            this.size = size;
            this.color = color;
        }

        // Reposition collectable after player collision (TODO: Add CollisionHandler)
        public void Position()
        {
            System.Random rand = new System.Random();
            position = new Vector2(rand.Next(0, (int)(Game.WindowWidth - size.X)), rand.Next(0, (int)(Game.WindowHeight - size.Y)));
        }
    }
}
