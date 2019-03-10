using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Player player;
    public float resetTime = 5.0f;

    void Start() {

    }

    void Update() {
        if(!player.HoldingBall) {
            resetTime -= Time.deltaTime;

            if(resetTime <= 0) {
                SceneManager.LoadScene("Game");

            }

        }

    }

}
