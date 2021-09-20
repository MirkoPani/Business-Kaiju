using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller bs;

    //public BossManager instance;

    public int health;

    public MoneyBossBar healthBar;

    public int MoneyToDecreasePerMissedNote = 5;
    public int MoneyToIncreasePerNote = 1;

    public DialogManager dialogManager;
    public StoryElement endingDialog;

    public event Action<object> FightEnded;
    public bool IsFightRunning
	{
        get;
        private set;
	}

    private bool _fightEnded;

    public string SceneToLoadAfterBoss;

    public ParticleSystem ps;

    // Start is called before the first frame update
    void Awake()
    {
        //instance = this;
        dialogManager.DialogClosed += StartFight;
    }

	private void StartFight(object obj)
	{
        if (!startPlaying)
        {
            IsFightRunning = true;
                startPlaying = true;
                bs.hasStarted = true;

                theMusic.Play();
            ps.Play();
        }

        //A cutscene finishes when the fight ended, change level
        if(_fightEnded)
		{
            SceneManager.LoadScene(SceneToLoadAfterBoss);
		}

    }

    public void StopFight()
	{
        ps.Stop();
        IsFightRunning = false;
        _fightEnded = true;
        //Invoke action
        FightEnded?.Invoke(this);

        theMusic.Stop();
        bs.Stop();
        healthBar.Hide();
        endingDialog.TriggerDialog();
	}


	// Update is called once per frame
	//void Update()
 //   {
 // //      if(!startPlaying)
	//	//{
 // //          if(Input.anyKeyDown)
	//	//	{
 // //              startPlaying = true;
 // //              bs.hasStarted = true;

 // //              theMusic.Play();
	//	//	}
	//	//}
 //   }

	private void OnDestroy()
	{
        dialogManager.DialogClosed -= StartFight;
    }

	public void NoteHit()
	{
        Debug.Log("Hit");
        healthBar.IncrementMoney(MoneyToIncreasePerNote);
	}

    public void NoteMissed()
	{
        Debug.Log("Missed");
        healthBar.DecreaseMoney(MoneyToDecreasePerMissedNote);
    }

}
