using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
	public Dialog dialogue;
	public bool Autostart;


	private void Start()
	{
		if(Autostart)
			TriggerDialog();
	}

	public void TriggerDialog()
	{
		FindObjectOfType<DialogManager>().StartDialog(dialogue);
	}

}
