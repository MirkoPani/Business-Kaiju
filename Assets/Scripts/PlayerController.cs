using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Public variables
    public float horizontalSpeed = 3.0f;
    public float verticalSpeed = 3.0f;
    public float jumpGap = 10.0f;
    public int maxHealth = 3;
    public int health { get { return currentHealth; } }

    //public bool stopCamera = false;
    private SpriteRenderer spriteRenderer;

    // Private variablez
    Rigidbody2D rigidBody;
    float vertical;
    int direction = 0;
    int currentHealth;
    int currentLane = 2;

    public Image[] HealthImages;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown("down"))
        {
            direction = -1;
        }
    }

    void FixedUpdate()
    {

        Vector2 position = rigidBody.position;

        position.x = position.x + horizontalSpeed * Time.deltaTime;

        if ((currentLane == 0 && direction == -1) || (currentLane == 3 && direction == 1))
        {
            // Needed
        }
        else
        {
            position.y = position.y + jumpGap * direction;
            currentLane += direction;
        }

        rigidBody.MovePosition(position);
        direction = 0;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth == 0)
            GameManager.instance.GameOver();

        if (currentHealth != 0)
            HealthImages[currentHealth].color = new Color(89f / 255f, 81 / 255f, 81 / 255f, 170 / 255f);

        StartCoroutine(DamageFlash());

    }

	private IEnumerator DamageFlash()
	{
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        spriteRenderer.color = Color.white;
        yield return null;
    }

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//    tag = collision.tag;

	//    if (tag == "Finish")
	//        stopCamera = true;

	//}
}
