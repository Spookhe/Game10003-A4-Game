using System;
using System.Numerics;
using group4_a4_project;

namespace Game10003
{
    public class CollisionHandler
    {
        private Collectable[] collectables;
        private Player player;
        public int playerScore = 0;

        // Constructor for collectables and player collision
        public CollisionHandler(Collectable[] collectableArray, Player playerObject)
        {
            player = playerObject;
            collectables = collectableArray;

        }

        // Loop through and handle all collectables in a given array
        public void Update()
        {
            for (int collectableIndex = 0; collectableIndex < collectables.Length; collectableIndex++)
            {
                Handle(collectables[collectableIndex]);
            }
        }

        /// <summary>
        /// Checks for Rect - Rect Collision between the player and a collectable
        /// Adds 100 score each time collision is true
        /// </summary>
        /// <param name="currentCollectable"></param>
        void Handle(Collectable currentCollectable)
        {
            // Calculate player hitbox
            Vector2 playerTopLeft = player.position;
            Vector2 playerBottomRight = new Vector2(player.position.X + player.size, player.position.Y + player.size);  // Updated to match player size

            // Calculate the collectable hitbox
            Vector2 collectableTopLeft = currentCollectable.position;
            Vector2 collectableBottomRight = new Vector2(currentCollectable.position.X + currentCollectable.size.X, currentCollectable.position.Y + currentCollectable.size.Y);

            // Checks if player hitbox collides with collectable hitbox
            if (playerTopLeft.X < collectableBottomRight.X && playerBottomRight.X > collectableTopLeft.X &&
                playerTopLeft.Y < collectableBottomRight.Y && playerBottomRight.Y > collectableTopLeft.Y)
            {
                // Add score if player collides with collectable
                playerScore += 100;

                // One-shot collect sounds
                if (playerScore % 1000 == 0)  // If score is 1000
                {
                    GameSounds.PlayCollect1000Sound();
                }
                else
                {
                    GameSounds.PlayCollectSound();
                }

                // Relocate the collectable after it is collected (Random)
                currentCollectable.Position();
            }
        }
    }
}
