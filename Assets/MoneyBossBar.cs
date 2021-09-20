using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyBossBar : MonoBehaviour
{
	public string SceneToLoad;
    public Slider slider;

	public BossManager bossManager;

	public void SetMaxMoney(int money)
	{
		slider.maxValue = money;
		slider.value = money;
	}

    public void SetMoney(int money)
	{
		slider.value = money;
	}

	public void IncrementMoney(int money)
	{
		if (money + slider.value < slider.maxValue)
			slider.value += money;
		else
		{
			slider.value = slider.maxValue;
			Debug.Log("Win");

			bossManager.StopFight();
		}
			
	}

	public void DecreaseMoney(int money)
	{
		
		if (slider.value - money > slider.minValue)
			slider.value -= money;
		else
		{
			slider.value = 0;
			Debug.Log("Lose");
			GameManager.instance.GameOver();
		}
			

	}

	internal void Hide()
	{
		gameObject.SetActive(false);
	}
}
