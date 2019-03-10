using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject trailParticles;

    void Start() {
        trailParticles.SetActive(false);

    }

    public void ActivateTrail() {
        trailParticles.SetActive(true);

    }

}
