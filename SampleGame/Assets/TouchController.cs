/*
 * Single touch controller script by Plasmoxy
 * This script is BAD. Dont use it even if your life depended on it.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TouchController : MonoBehaviour {

	public GameObject cube, torus, counterText;
	public Material mat_a, mat_b;

	private bool touched;

	private long cubeCount;

	private GameObject getCurrentCube()
	{
		return GameObject.Find("Cube#" + cubeCount.ToString());
	}

	private Vector3 getPosByTouch(Touch t)
	{
		return Camera.main.ScreenToWorldPoint(new Vector3(t.position.x + Screen.width / 10, t.position.y, 10));
	}

	private void processTouch(Touch t) // probably should rewrite it through switch !
	{
		Vector3 touchPos = getPosByTouch(t);
		if (t.phase == TouchPhase.Began && !touched)
		{
			Debug.Log("TOUCH");
			touched = true;
			cubeCount++;
			Vector3 newPos = getPosByTouch(t);
			newPos.z = 0; // fix z pos
			if (touchPos.y > torus.transform.position.y) // if its higher than the torus
			{
				GameObject newCube = Instantiate(cube, newPos, Quaternion.identity);
				newCube.name = "Cube#" + cubeCount.ToString();
				newCube.GetComponent<Renderer>().material = Random.value > 0.5f ? mat_a : mat_b;
			}
		}
		else if (t.phase == TouchPhase.Moved && touched && touchPos.y > torus.transform.position.y)
		{
			Debug.Log("MOVE");
			Vector3 newPos = touchPos;
			newPos.z = 0;
			getCurrentCube().transform.position = newPos;
		}
		else if ((t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled) && touched && touchPos.y > torus.transform.position.y)
		{
			Debug.Log("RELEASE");
			touched = false;
			GameObject c = getCurrentCube();
			if (c == null) return; // totally hardcoded null reference bugfix, need to rewrite the whole script but good for a begginer lol
			Debug.Log("CREATED " + c.name);
			c.GetComponent<Rigidbody>().useGravity = true; // enable gravity after releasing cube
			counterText.GetComponent<TextMesh>().text = cubeCount.ToString();
		}
	}

	void Start () {}
	
	void FixedUpdate () {

		if (Input.touchCount > 0)
		{
			processTouch(Input.GetTouch(0));
		}
	}
}
