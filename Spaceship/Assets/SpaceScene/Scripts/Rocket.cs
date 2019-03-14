using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody body;
    private bool areParticlesPlaying = false;
    private float bulletTimer;

    public ParticleSystem rightParticles;
    public ParticleSystem leftParticles;
    public float bulletsPerSecond = 1.0f;

    public Bullet bulletModel;
    public int shootingForce = 1000;

    void Start() {
        body = GetComponent<Rigidbody>();
        bulletTimer = 1.0f / bulletsPerSecond;
        rightParticles.Stop();
        leftParticles.Stop();

    }

    void Update() {
        if(Input.GetButton/*Down*/("Fire1")) {
            if(bulletTimer < 0) {
                Vector3 cannonOffset = transform.forward * 1.1501f;
                Bullet bullet = Instantiate(bulletModel, transform.position + cannonOffset, transform.rotation); //instantiate bullet at the position of rocket
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootingForce); //shoot the bullet
                bullet.StartDestroyTimer(); //destroy the bullet after a few seconds
                bulletTimer = 1.0f / bulletsPerSecond;

            }

        }
        bulletTimer -= Time.deltaTime;

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
