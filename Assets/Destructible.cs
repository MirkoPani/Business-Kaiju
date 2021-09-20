using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : Collidable
{
	public int ScoreToGive = 10;
	public GameObject explosionPrefab;

	protected override void OnCollide(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			GameManager.instance.Score += ScoreToGive;
			Destroy(gameObject);
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}

	}
}
