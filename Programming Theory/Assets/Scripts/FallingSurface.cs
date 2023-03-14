using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSurface : Surface
{
    private bool timeIsUp = false;
    private bool isTimerStarted = false;
    private const float timeBeforeFall = 2;

    protected override void ChangeIsTrigger()
    {
        if (player != null && player.transform.position.y > transform.position.y + positionLag && !timeIsUp)
        {
            // If player's collider above the surface and the surface is not falling
            surfaceCollider.isTrigger = false;
        }
        else if (player != null && (player.transform.position.y < transform.position.y - positionLag || timeIsUp))
        {
            // If player's collider under the surface or the surface is falling
            surfaceCollider.isTrigger = true;
        }
    }

    protected override void ChangeUseGravity()
    {
        if (timeIsUp)
        {
            // Surface will fall
            surfaceRb.useGravity = true;
            surfaceRb.isKinematic = false;
        }
    }

    IEnumerator WaitBeforeFall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        timeIsUp = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isTimerStarted && !surfaceCollider.isTrigger)
        {
            // When player jumps on surface
            StartCoroutine(WaitBeforeFall());
            isTimerStarted = true;
        }
    }
}
