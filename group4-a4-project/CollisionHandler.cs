using System;
using System.Numerics;

namespace Game10003;
// WB-CALLBRA01

public class CollisionHandler
{
    Vector2[] collectables;
    Vector2 player;
    int playerSize = 50;
    int collectableSize = 50;

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

    void Handle(Vector2 currentCollectable)
    {
        Vector2 playerTopLeft = new Vector2(player.X, player.Y);
        Vector2 playerTopRight = new Vector2(player.X + playerSize, player.Y);
        Vector2 playerBottomLeft = new Vector2(player.X, player.Y + playerSize);
        Vector2 playerBottomRight = new Vector2(player.X + 50, player.Y + 50);

        Vector2 collectableTopLeft = new Vector2(currentCollectable.X, currentCollectable.Y);
        Vector2 collectableTopRight = new Vector2(currentCollectable.X + collectableSize, currentCollectable.Y);
        Vector2 collectableBottomLeft = new Vector2(currentCollectable.X, currentCollectable.Y + collectableSize);
        Vector2 collectableBottomRight = new Vector2(currentCollectable.X + collectableSize, currentCollectable.Y + collectableSize);
    }

}
