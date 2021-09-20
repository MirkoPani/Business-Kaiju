using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindedText : MonoBehaviour
{
	private Text textComponent;
	public bool bindsMoney;


    // Start is called before the first frame update
 //   void Start()
 //   {
	//	textComponent = GetComponent<Text>();

	//	if (bindsMoney)
	//		textComponent.text = GameManager.instance.CurrentMoney.ToString();
	//	else
	//		textComponent.text = GameManager.instance.CurrentExperience.ToString();


	//	GameManager.instance.PropertyChanged += UpdateText;
 //   }

	//private void UpdateText(object sender, string propertyname)
	//{
	//	if(propertyname == nameof(GameManager.instance.CurrentExperience) && bindsMoney==false)
	//	{
	//		textComponent.text = GameManager.instance.CurrentExperience.ToString();
	//	}

	//	if (propertyname == nameof(GameManager.instance.CurrentMoney) && bindsMoney==true)
	//	{
	//		textComponent.text = GameManager.instance.CurrentMoney.ToString();
	//	}


	//}

	//private void OnDestroy()
	//{
 //       GameManager.instance.PropertyChanged -= UpdateText;
 //   }

	


	// Update is called once per frame
	void Update()
    {
        
    }
}
