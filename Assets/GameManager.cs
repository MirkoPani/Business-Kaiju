using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseModel
{
    public static GameManager instance;

	private long _score;

	public long Score
	{
		get
		{
			return _score;
		}
		set
		{
			SetProperty<long>(ref _score, value, "Score");
		}
	}

	private long ScoreWhenLoadingLastLevel;

	public bool PlayerWasKilled;

	public GameOverScreen GameOverScreen;

	string previousScene;

	public void GameOver()
	{
		Time.timeScale = 0;
		instance.previousScene = SceneManager.GetActiveScene().name;

		SceneManager.LoadScene("GameOver");
	}
 
	public void GoToLevel(string sceneName)
	{
		instance.ScoreWhenLoadingLastLevel = Score;
		//Teleport player
		SceneManager.LoadScene(sceneName);
	}

	
	private void Awake()
	{
		if (GameManager.instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;

		DontDestroyOnLoad(gameObject);
	}

	public void RestartLevel()
	{
		SetValuesAsPrevious();
		SceneManager.LoadScene(instance.previousScene);
		Time.timeScale = 1;
	}

	private void SetValuesAsPrevious()
	{
		instance.Score = instance.ScoreWhenLoadingLastLevel;
	}

	public void ResetGame()
	{
		ResetValues();
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1;
	}

	private void ResetValues()
	{
		instance.ScoreWhenLoadingLastLevel = 0;
		instance.Score = 0;
	}

}
