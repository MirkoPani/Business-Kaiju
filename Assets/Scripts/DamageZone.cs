using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public GameObject explosionPrefab;
    private AudioSource audio;

	private void Start()
	{
        audio = GetComponent<AudioSource>();
	}


	private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            audio.PlayOneShot(audio.clip);
            playerController.ChangeHealth(-1);

            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
