using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool stopCamera = false;

    Vector3 offset;
    Vector3 movement;

    public bool followingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        offset.y = 0.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(followingPlayer)
        {
            movement.x = player.transform.position.x;
            movement.y = transform.position.y;
            movement.z = player.transform.position.z;

            transform.position = movement + offset;
        }
        
    }
}
