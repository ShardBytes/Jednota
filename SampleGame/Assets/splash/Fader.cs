using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

	public Texture2D fadeTexture;
	public float fadeSpeed = 0.8f;

	private int drawDeph = -1000; // draw texture on top
	private float alpha = 1.0f;
	private int fadeDir = -1; // direction of fade

	void OnGUI() { // run on gui renderer
		alpha += fadeDir * fadeSpeed * Time.deltaTime; // split the fade through deltaTime so its <fadeSpeed> per second

		alpha = Mathf.Clamp01(alpha); // restrict alpha to <0,1> range

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); // set this GUI alpha
		GUI.depth = drawDeph;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
	}

}
