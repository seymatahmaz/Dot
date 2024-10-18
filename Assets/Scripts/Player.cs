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
    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.W);

        if (horizontalInput != 0) {
            playerRigidBody.velocity = new Vector2(horizontalInput * speed, playerRigidBody.velocity.y);
        }

        if (jumpInput && grounded) {
            playerRigidBody.AddForce(new Vector2(0, jumpForce));
            grounded = false;
        }
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
