using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsHud : MonoBehaviour
{

    private BossManager bossManager;

    // Start is called before the first frame update
    void Start()
    {
        bossManager = FindObjectOfType<BossManager>();
        bossManager.FightEnded += Stop;
    }

	private void Stop(object obj)
	{
        gameObject.SetActive(false);
	}

    private void OnDestroy()
    {
        bossManager.FightEnded -= Stop;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
