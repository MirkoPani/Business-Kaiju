using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdateListener : MonoBehaviour
{
	
	private Text textComponent;

	private void Start()
	{
		GameManager.instance.PropertyChanged += HandleScoreUpdate;
		textComponent = GetComponent<Text>();
		textComponent.text = GameManager.instance.Score.ToString();
	}

	private void HandleScoreUpdate(object arg1, string arg2)
	{
		if(arg2 == "Score")
		{
			textComponent.text = GameManager.instance.Score.ToString();
		}
	}

	private void OnDestroy()
	{
		GameManager.instance.PropertyChanged -= HandleScoreUpdate;
	}



}
