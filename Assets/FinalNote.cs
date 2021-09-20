using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNote : Collidable
{
	protected override void OnCollide(Collider2D coll)
	{
		if(coll.name == "EndTrigger")
		{
			Debug.Log("visible");
			GameManager.instance.GameOver();
		}
	}
}
