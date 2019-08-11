using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour {

    private float originalPos;
    private Transform groundPos;
    public float speed = -3f;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        originalPos = gameObject.transform.position.y;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (gameObject.transform.position.y >= originalPos) {
            speed = -5f;
        }
        move();
    }

    private void move() {
        //transform.Translate(0, speed * Time.deltaTime, 0);
        //rb.velocity = new Vector3(0, speed *20 * Time.deltaTime, 0);
        rb.velocity = new Vector3(0, speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //if (collision.gameObject.name == "Grass") {
        //    groundPos = gameObject.transform;
        //    speed = 3f;
        //}

        groundPos = gameObject.transform;
        speed = 3f;
    }
}
