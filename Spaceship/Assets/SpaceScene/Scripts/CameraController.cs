using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Rocket rocket;
    private Vector3 positionOffset;
    private Quaternion rotationOffset;

    void Start() {
        //positionOffset = transform.position - rocket.transform.position;
        //rotationOffset = transform.rotation;

    }

    void Update() {

    }

    void LateUpdate() {
        //transform.position = rocket.transform.position + positionOffset;
        //transform.rotation = rocket.transform.rotation;

    }

}
