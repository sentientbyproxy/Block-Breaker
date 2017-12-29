using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    private void Update() {
        if (!hasStarted)
        {
            //lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0)) {
                print("Mouse clicked, launch ball");
                hasStarted = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        gameObject.GetComponent<Rigidbody2D>().velocity += tweak;
    }
    public void reset() {
        hasStarted = false;
        //  Debug.Log("Ball reset");
    }
}