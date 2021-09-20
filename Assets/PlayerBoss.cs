using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoss : MonoBehaviour
{
    public int maxMoney = 100;
    public int currentMoney;


    // Start is called before the first frame update
    void Start()
    {
        currentMoney = maxMoney;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            TakeDamage(20);
		}
    }

    void TakeDamage(int damage)
	{
        currentMoney -= damage;
	}

}
