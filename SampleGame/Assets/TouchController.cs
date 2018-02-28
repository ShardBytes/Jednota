/*
 * Single touch controller script by Plasmoxy
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TouchController : MonoBehaviour {

	public GameObject cube, torus;
	public Material mat_a, mat_b;
	private bool touched;

	private long cubeIterator;

	private GameObject getCurrentCube()
	{
		return GameObject.Find("Cube#" + cubeIterator.ToString());
	}

	private Vector3 getPosByTouch(Touch t)
	{
		return Camera.main.ScreenToWorldPoint(new Vector3(t.position.x + Screen.width / 10, t.position.y, 10));
	}

	void Start () {}
	
	void FixedUpdate () {

		if (Input.touchCount > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began && !touched)
			{
				touched = true;
				Vector3 newPos = getPosByTouch(t);
				newPos.z = 0; // fix z pos
				if (newPos.y > torus.transform.position.y) // if its higher than the torus
				{
					GameObject newCube = Instantiate(cube, newPos, Quaternion.identity);
					newCube.name = "Cube#" + cubeIterator.ToString();
					newCube.GetComponent<Renderer>().material = Random.value > 0.5f ? mat_a : mat_b;
				}
			}
			else if (t.phase == TouchPhase.Moved && touched)
			{
				Vector3 newPos = getPosByTouch(t);
				newPos.z = 0;
				getCurrentCube().transform.position = newPos;
			}
			else if ( (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled) && touched)
			{
				GameObject c = getCurrentCube();
				Debug.Log("CREATED " + c.name);
				c.GetComponent<Rigidbody>().useGravity = true; // enable gravity after releasing cube
				cubeIterator++;
				touched = false;
			}
		}
	}
}
