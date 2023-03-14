using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSurface : Surface
{
    // Brick is always hard. Player can't go through it.
    
    private void Start()
    {
        surfaceCollider.isTrigger = false;
    }

    protected override void ChangeIsTrigger()
    {
        
    }
}
