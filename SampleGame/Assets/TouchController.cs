/*
 * Single touch controller script by Plasmoxy
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TouchController : MonoBehaviour {

	public GameObject cube;
	public Material mat_a, mat_b;
	private bool touched;

	private long cubeIterator;

	private GameObject getCurrentCube()
	{
		return GameObject.Find("Cube#" + cubeIterator.ToString());
	}

	void Start () {}
	
	void FixedUpdate () {

		if (Input.touchCount > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began && !touched)
			{
				touched = true;
				Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
				newPos.z = 0; // fix z pos
				if (newPos.y > 0)
				{
					GameObject newCube = Instantiate(cube, newPos, Quaternion.identity);
					newCube.name = "Cube#" + cubeIterator.ToString();
					newCube.GetComponent<Renderer>().material = Random.value > 0.5f ? mat_a : mat_b;
				}
			}
			else if (t.phase == TouchPhase.Moved && touched)
			{
				Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
				newPos.z = 0;
				getCurrentCube().transform.position = newPos;
			}
			else if (t.phase == TouchPhase.Ended && touched)
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
