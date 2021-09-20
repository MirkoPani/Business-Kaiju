using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    private BossManager bossManager;

    // Start is called before the first frame update
    void Start()
    {
         bossManager = FindObjectOfType<BossManager>();
        bossManager.FightEnded += Delete;
    }

	private void OnDestroy()
	{
        if(bossManager!= null)
            bossManager.FightEnded -= Delete;
    }

	private void Delete(object obj)
	{
        gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKey(keyToPress))
		{
            if(canBePressed)
			{
                gameObject.SetActive(false);

                Debug.Log("Note hit");
                bossManager.NoteHit();
			}
		}

       
    }

    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Activator")
		{
            canBePressed = true;
		}

	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            if(gameObject.activeSelf)
			{
                bossManager.NoteMissed();
                Debug.Log("Note missed");
            }
                
        }

    }

}
