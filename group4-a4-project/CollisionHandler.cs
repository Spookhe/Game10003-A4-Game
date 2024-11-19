using System;
using System.Numerics;

namespace Game10003;
// WB-CALLBRA01

public class CollisionHandler
{
    Vector2[] collectables;
    Vector2 player;

    public CollisionHandler(Vector2[] collectableArray, Vector2 newPlayer)
    {
        player = newPlayer;
        collectables = collectableArray;
    }

    public void Update()
    {

    }

    void Handle(Vector2 currCollectable)
    {

    }

}
