using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrapMovement : MonoBehaviour
{

    public float playerSpeed = 0.5f;
    public string submitButton = "Jump_P1";
    public string verticalCtrl = "Vertical_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public bool move;

    //private Rigidbody2D rb;

    private void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) {
            //if (Input.GetButton(horizontalCtrl)) {
            //    transform.Translate(Vector2.right * playerSpeed, Space.World);
            //}
            //if (Input.GetButton(horizontalCtrl)) {
            //    transform.Translate(Vector2.right * playerSpeed, Space.World);
            //}


            transform.Translate(Vector2.right * playerSpeed * Input.GetAxisRaw(horizontalCtrl), Space.World);
            transform.Translate(Vector2.up * playerSpeed * Input.GetAxisRaw(verticalCtrl), Space.World);

            //Using rigid body makes it potenatilly get stuck at spawn 
            //rb.velocity=(new Vector3(playerSpeed * Input.GetAxisRaw(horizontalCtrl), playerSpeed * Input.GetAxisRaw(verticalCtrl), 0f));
        }

        //Debug.Log(Input.GetAxis(horizontalCtrl));

        if (Input.GetButtonDown(submitButton)) {
            Debug.Log("Trap A pressed");
            move = false;
        }
    }

}
