/* Fade script by Plasmoxy */
/* Dont use this even if your life depended on it */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour {

	public Image splashImage;
	public string nextScene;
	public float remainDuration = 1f; // remain duration of the splashImage
	public float fadeInDuration = 1.5f;
	public float fadeOutDuration = 1.5f;


	// coroutine starts internally,no need to call it, just keep the code in start

	IEnumerator Start() {
		splashImage.canvasRenderer.SetAlpha(0.0f); // hide image at start

		FadeIn();
		yield return new WaitForSeconds(fadeInDuration + remainDuration); // let the coroutine wait for fadein and remain

		FadeOut();
		yield return new WaitForSeconds(fadeOutDuration); // let the coroutine wait for fadeout

		SceneManager.LoadScene(nextScene);
	}

	void FadeIn() {
		splashImage.CrossFadeAlpha(1.0f, fadeInDuration, false); // fade to fully visible by the time of 1.5 seconds
	}

	void FadeOut() {
		splashImage.CrossFadeAlpha(0.0f, fadeOutDuration, false); // fade to fully invisible
	}

}
