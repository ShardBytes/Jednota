using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveClickCounter : MonoBehaviour {

	public Text guiText;
	public Button hiveButton;
	private int clickNum = 0;

	void Start(){
		hiveButton.onClick.AddListener(addNumber);
	}

	void addNumber(){
		clickNum = Int32.Parse(guiText.text);
		clickNum = clickNum + 1;
		guiText.text = clickNum.ToString();
	}

}
