using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;

	public Text nameText;
	public Text dialogText;

	public Animator animator;
	public AudioSource audiosource;

	public event Action<object> DialogClosed;

	internal void StartDialog(Dialog dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(var sent in dialogue.sentences)
		{
			sentences.Enqueue(sent);
		}

		DisplayNextSentence();

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialog();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		audiosource.Play();
		dialogText.text = "";

		bool colorMode = false;

		foreach(var letter in sentence.ToCharArray())
		{
			if (letter == '*')
			{
				colorMode = !colorMode;
				continue;
			}
				
			if(colorMode)
			{
				dialogText.text += "<color=orange>"+letter+"</color>";
			}
			else
			{
				dialogText.text += letter;
			}

			yield return new WaitForSeconds(0.04f);
		}
		audiosource.Stop();
	}

	void EndDialog()
	{
		animator.SetBool("IsOpen", false);
		audiosource.Stop();

		DialogClosed?.Invoke(this);

	}

	// Start is called before the first frame update
	void Awake()
    {
        sentences = new Queue<string>();
		audiosource = GetComponent<AudioSource>();
    }

   
}
