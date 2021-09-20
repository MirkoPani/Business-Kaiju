using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool fireRocket = false;
    public GameObject explosionPrefab;

    Rigidbody2D rb;
    public AudioSource explosionSrc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireRocket)
        {
            Vector2 movement = rb.position;

            movement.x = movement.x - speed * Time.deltaTime;

            rb.MovePosition(movement);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            AudioSource.PlayClipAtPoint(explosionSrc.clip, transform.position);
            playerController.ChangeHealth(-1);
            Destroy(gameObject);

            Instantiate(explosionPrefab, rb.transform.position, Quaternion.identity);
        }

    }
}
