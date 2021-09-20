using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    float timer;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 10.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if(playerController != null)
        {
            playerController.ChangeHealth(-1);
        }

        Destroy(gameObject);
    }

    public void Shoot(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }
}
