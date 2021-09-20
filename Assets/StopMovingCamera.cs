using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovingCamera : Collidable
{
    public Camera cam;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag =="Player")
        {
            cam.GetComponent<CameraController>().followingPlayer = false;
        }
    }
}
