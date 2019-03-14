using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletLifeTime = 5.0f;

    public void StartDestroyTimer() {
        Destroy(gameObject, bulletLifeTime);
    }

}
