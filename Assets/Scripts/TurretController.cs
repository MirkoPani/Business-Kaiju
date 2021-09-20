using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Collidable
{
    public int ScoreToGive = 15;
    public GameObject explosionPrefab;

    public AudioSource audiosrc;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameManager.instance.Score += ScoreToGive;
            AudioSource.PlayClipAtPoint(audiosrc.clip, transform.position);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
