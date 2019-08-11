using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private int runSpeed = 14;
    private int normalSpeed = 7;
    public int playerSpeed = 7;
    public bool facingRight = true;
    public bool facingRightPrev = true;
    private int playerJumpPower = 7;


    public bool canJump = false;

    public PlayerCoins playerCoinManager;
    public PlayerEscaped playerEscapeManager;

    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 3.5f;
    Rigidbody2D rb;

    public string jumpButon = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public string runButton = "Run_P1";

    //References for report
    //YouTube:
    //2D Sice Scroller Tutorial
    //Better Jumping in Unity with Four Lines of Code
    //Creating a 2D Platformer Ep9 wall jumping

    private Animator animator;
    private AudioSource audioSource;
    public AudioClip deathSound;
    public AudioClip RunningSound;
    public AudioClip JumpingSound;
    public AudioClip CoinPickupSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        // Weighted jump "Better Jumping in Unity with Four Lines of Code"
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
        else if (rb.velocity.y > 0 && !Input.GetButton(jumpButon))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        //if (Input.GetButtonDown("Jump") && canJump) {
        if (Input.GetButtonDown(jumpButon) && canJump)
            {
                Jump();
        }
        //float horAxis = Input.GetAxis("Horizontal");
        float horAxis = Input.GetAxis(horizontalCtrl);
        if (horAxis == 0)
        {
            animator.SetBool("Moving", false);
        }
        else {
            animator.SetBool("Moving", true);
            //audioSource.clip = RunningSound;
            //audioSource.PlayOneShot(RunningSound);
        }
        if (horAxis < 0)
        {
            facingRight = false;
        }
        else {
            facingRight = true;
        }
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetButton(runButton))
        {
            playerSpeed = runSpeed;
            animator.SetBool("Running", true);
        }
        else {
            playerSpeed = normalSpeed;
            animator.SetBool("Running", false);

        }

        //From YouTube "2D Sice Scroller Tutorial"
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(horAxis * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horAxis * 50 * playerSpeed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y));
        //if on ice add a force with velocity 
        //if (onIce) {
        //    Debug.Log("Add slippery force");
        //    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horAxis * playerSpeed * 100 , gameObject.GetComponent<Rigidbody2D>().velocity.y));
        //    //if on ice add a force 
        //}

    }

    void Jump() {
        //Weighted jump "Better Jumping in Unity with Four Lines of Code"
        GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpPower;
        animator.SetTrigger("Jumping");
        audioSource.PlayOneShot(JumpingSound);
        canJump = false;

    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Jumpable")
        {
            canJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GameObject2 collided with " + other.name);
    
        if (other.gameObject.tag == "FallDeath")
        {
            die();

        }

        if (other.gameObject.tag == "Trap") {
            die();
        }

        if (other.gameObject.tag == "Safehouse")
        {

            Debug.Log("Well Done");
            playerEscapeManager.reachedSafeHouse();
            playerCoinManager.finishLevel();
            gameObject.SetActive(false);
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.transform.GetComponentInChildren<ParticleSystem>().Emit(100);
            //other.gameObject.GetComponent<ParticleSystem>().Emit(100);
            //winButton.gameObject.SetActive(true);

        }
        if (other.gameObject.tag == "Collectable")
        {
            //play pick up sound
            audioSource.PlayOneShot(CoinPickupSound);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Player has collided with " + other.collider);
        if (other.gameObject.tag == "Jumpable")
        {
            canJump = true;
        }
        else if (other.gameObject.tag == "Player") {
            canJump = true;
        }
        if (other.gameObject.tag == "Trap")
        {
            die();
        }


    }
    
    public void die() {
        playerCoinManager.dropTempCoins();
        
        //Doesnt play due to deactive game object immediately 
        audioSource.PlayOneShot(deathSound);

        gameObject.SetActive(false);
        Debug.Log("Player Died");
        
    }
}
