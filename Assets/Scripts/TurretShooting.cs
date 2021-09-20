using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootChargeTime = 5.0f;
    public float bulletSpeed = 250f;

    bool playerInRange = false;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.tag;

        if (tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tag = collision.tag;

        if (tag == "Player")
        {
            playerInRange = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        tag = collision.tag;

        if (tag == "Player")
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Vector3 direction = collision.transform.position - transform.position;

                Shoot(direction);
                timer = shootChargeTime;
            }
        }
    }

    void Shoot(Vector3 direction)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector2 shootDirection = new Vector2(direction.x, direction.y);

        shootDirection.Normalize();

        BulletController bullet = projectileObject.GetComponent<BulletController>();
        bullet.Shoot(shootDirection, bulletSpeed);
    }
}
