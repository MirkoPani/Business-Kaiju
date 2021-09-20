using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToNewLevel : Collidable
{
	public string sceneName;
	protected override void OnCollide(Collider2D coll)
	{
		if (coll.name == "Player")
		{
			GameManager.instance.GoToLevel(sceneName);
		}
	}
}
