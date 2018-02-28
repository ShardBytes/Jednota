using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TouchController : MonoBehaviour {

	public GameObject cube;
	public Material mat_a, mat_b;
	private bool touched;

	private long cubeIterator;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {

		if (Input.touchCount > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began && !touched)
			{
				touched = true;
				Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
				if (newPos.y > 0)
				{
					GameObject newCube = Instantiate(cube, newPos, Quaternion.identity);
					newCube.name = "Cube#" + cubeIterator.ToString();
					newCube.GetComponent<Renderer>().material = Random.value > 0.5f ? mat_a : mat_b;
				}
			}
			/*else if (t.phase == TouchPhase.Moved && touched)
			{
				Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
				newCube.transform.position = newPos; // if has a cube reference
			}*/
			else if (t.phase == TouchPhase.Ended && touched)
			{
				Debug.Log("CREATED Cube#" + cubeIterator.ToString());
				cubeIterator++;
				touched = false;
			}
		}
	}
}
