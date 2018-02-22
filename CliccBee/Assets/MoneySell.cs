using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySell : MonoBehaviour {

	public Text honeyCount;
	public Text moneyCount;
	public Button dollarButton;
	private static int honeyAmount = 0;
	private static int moneyAmount = 0;

	void Start(){
		dollarButton.onClick.AddListener(sellHoney);
	}

	void sellHoney(){
		honeyAmount = Int32.Parse(honeyCount.text);
		moneyAmount = moneyAmount + honeyAmount / 10;
		honeyCount.text = "0";
		moneyCount.text = moneyAmount.ToString();
	}

}
