using System;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace Game10003;
// WB-CALLBRA01

public class CollisionHandler
{
    Vector2[] collectables;
    Vector2 player;
    int playerSize = 50;
    int collectableSize = 50;
    public int playerScore = 0;

    // TODO: WHEN COLLECTABLE AND PLAYER ARE DONE, USE CLASSES NOT V2'S
    public CollisionHandler(Vector2[] collectableArray, Vector2 newPlayer)
    {
        player = newPlayer;
        collectables = collectableArray;
    }

    /// <summary>
    /// Loop through and handle all collectables in a given array
    /// </summary>
    public void Update()
    {
        for (int collectableIndex = 0; collectableIndex < collectables.Length; collectableIndex++)
        {
            Handle(collectables[collectableIndex]);
        }
    }

    /// TODO: ADD CURRENTCOLLECTABLE.isColliding WHEN COLLECTABLE CLASS IS DONE

    /// <summary>
    /// Checks for Rect - Rect Collision
    /// Adds 100 score each time collision is true
    /// </summary>
    /// <param name="currentCollectable"></param>
    void Handle(Vector2 currentCollectable)
    {
        // TL - Top Left | TR - Top Right | BL - Bottom Left | BR - Bottom Right
        // Get the x-y coord of every corner of the player sprite
        Vector2 playerTopLeft = new Vector2(player.X, player.Y);
        Vector2 playerTopRight = new Vector2(player.X + playerSize, player.Y);
        Vector2 playerBottomLeft = new Vector2(player.X, player.Y + playerSize);
        Vector2 playerBottomRight = new Vector2(player.X + 50, player.Y + 50);

        // Get the x-y coord of every corner of the current collectable sprite
        Vector2 collectableTopLeft = new Vector2(currentCollectable.X, currentCollectable.Y);
        Vector2 collectableTopRight = new Vector2(currentCollectable.X + collectableSize, currentCollectable.Y);
        Vector2 collectableBottomLeft = new Vector2(currentCollectable.X, currentCollectable.Y + collectableSize);
        Vector2 collectableBottomRight = new Vector2(currentCollectable.X + collectableSize, currentCollectable.Y + collectableSize);

        // Check for player's top left point
        if (playerTopLeft.X < collectableTopRight.X && playerTopLeft.X > collectableTopLeft.X)
        {
            if (playerTopLeft.Y < collectableBottomRight.Y && playerTopLeft.Y > collectableTopRight.Y)
            {
                //currentCollectable.isColliding = true;
                playerScore += 100;
            }
        }

        // Check for player's bottom left point
        if (playerTopLeft.X < collectableTopRight.X && playerTopLeft.X > collectableTopLeft.X)
        {
            if (playerTopLeft.Y + 50 < collectableBottomRight.Y && playerTopLeft.Y + 50 > collectableTopRight.Y)
            {
                //currentCollectable.isColliding = true;
                playerScore += 100;
            }
        }

        // Check for player's top right point
        if (playerTopRight.X > collectableTopLeft.X && playerTopRight.X < collectableTopRight.X)
        {
            if (playerTopRight.Y < collectableBottomLeft.Y && playerTopRight.Y > collectableTopLeft.Y)
            {
                //currentCollectable.isColliding = true;
                playerScore += 100;
            }
        }

        // Check for player's bottom right point
        if (playerTopRight.X > collectableTopLeft.X && playerTopRight.X < collectableTopRight.X)
        {
            if (playerTopRight.Y + 50 < collectableBottomLeft.Y && playerTopRight.Y + 50 > collectableTopLeft.Y)
            {
                //currentCollectable.isColliding = true;
                playerScore += 100;

            }
        }
    }
}
