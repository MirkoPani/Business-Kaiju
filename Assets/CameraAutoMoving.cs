using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoMoving : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
