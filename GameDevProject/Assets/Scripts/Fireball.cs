using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    public AnimationClip animationClipToPlay;
    private bool hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            //Stop 
            rb.velocity = Vector2.zero;
            rb.angularVelocity =0f;
        }
        else {
            //rb.velocity += transform.right * -speed * Time.deltaTime;
            rb.AddForce(transform.right * -speed * Time.deltaTime * 50);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        Animator animator = gameObject.GetComponent<Animator>();
        animator.Play("FireballDeathAnimation", 0, 0);
        Destroy(gameObject, animationClipToPlay.length);

    }
}
