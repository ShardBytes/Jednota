using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2.25f;
    public float throwingForce = 550.0f;

    public bool HoldingBall { get; private set; } = true;

    void Start() {
        ball.GetComponent<Rigidbody>().useGravity = false;

    }

    void Update() {
        if(HoldingBall) {
            //Forward is always one WU from the origin
            ball.transform.position = playerCamera.transform.position + (playerCamera.transform.forward * ballDistance);

            if(Input.GetMouseButtonDown(0)) {
                HoldingBall = false; 
                ball.ActivateTrail();

                ball.GetComponent<Rigidbody>().useGravity = true;

                //Add force in a direction Vector3
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * throwingForce);


            }

        }

    }

}
