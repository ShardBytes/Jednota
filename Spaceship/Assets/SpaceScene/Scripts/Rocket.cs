using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody body;
    private bool areParticlesPlaying = false;

    public ParticleSystem rightParticles;
    public ParticleSystem leftParticles;

    void Start() {
        body = GetComponent<Rigidbody>();
        rightParticles.Stop();
        leftParticles.Stop();

    }

    void FixedUpdate() {
        float xAxis = Input.GetAxis("ForwardBackward");
        float yAxis = Input.GetAxis("UpDown");
        float zAxis = Input.GetAxis("LeftRight");
        float spin = Input.GetAxis("Spin");

        if(xAxis + yAxis + zAxis + spin != 0) {
            body.AddForce(transform.forward * xAxis);
            body.AddTorque(transform.right * yAxis);   //no idea why these three
            body.AddTorque(transform.up * zAxis);      //make absolutely no sense
            body.AddTorque(transform.forward * spin);  //but it works so yeah

            if(!areParticlesPlaying) {
                areParticlesPlaying = true;
                rightParticles.Play();
                leftParticles.Play();

            }

        } else {
            if(areParticlesPlaying) {
                areParticlesPlaying = false;
                rightParticles.Stop();
                leftParticles.Stop();

            }

        }

    }

}
