using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWhenCutsceneEnds : MonoBehaviour
{
    public string SceneName;
    public DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager.DialogClosed += ChangeLevel;
    }

	private void ChangeLevel(object obj)
	{
        GameManager.instance.GoToLevel(SceneName);
	}

	private void OnDestroy()
	{
        dialogManager.DialogClosed -= ChangeLevel;
    }

}
