using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public MissileController missileController;
    public AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        missileController = GetComponentInParent<MissileController>();
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
            missileController.fireRocket = true;
            audiosrc.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
