using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpGUI : MonoBehaviour {

	public RectTransform panel;
	public Text text;
	// Use this for initialization
	void Start () {
	
		playerHp.HPChangedAction+=changeHP;
	}
	
	void changeHP(int newHP){
		panel.sizeDelta = new Vector2(newHP * 2f,25);
		text.text = newHP + " %";

		if (newHP <=0){
			playerHp.HPChangedAction-=changeHP;
		}
	}
}
