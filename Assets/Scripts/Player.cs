using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    public float speed;
    public float jumpForce = 10f;
    public TMP_Text coinText;
    private bool isLogWritten;
    private int coinCount;
    private float health =1f;
    private bool grounded;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);
        if (verticalInput != 0) {
            playerRigidBody.AddForce(new Vector2(0, verticalInput*speed));
        }
        if (horizontalInput != 0) {
            playerRigidBody.velocity = new Vector2(horizontalInput*speed, playerRigidBody.velocity.y)  ;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded){
            playerRigidBody.AddForce(new Vector2(0, jumpForce));
            grounded = false;
        }

        /* if (!isLogWritten) {
            for (int i = 0; i < 10; i++) {
                Debug.Log("i: " + i);
            }
            isLogWritten = true;
        }*/ 

        //playerRigidBody.AddForce(new Vector2(, 0));  
        //playerRigidBody.velocity = new Vector2(horizontalInput*speed, verticalInput*speed);  
    }

    private void OnCollisionEnter2D(Collision2D other) {
        switch (other.gameObject.tag){
            case "Coin":
                coinCount++;
                coinText.text = coinCount.ToString();
                Destroy(other.gameObject);
                break;
            case "Spike":
                health -= 0.1f;
                break;
            case "Floor":
                grounded = true;
                break;
        }
    }
}
