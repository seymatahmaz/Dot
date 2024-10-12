using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    public float speed;
    private bool isLogWritten;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0) {
            playerRigidBody.AddForce(new Vector2(0, verticalInput*speed));
        }
        if (horizontalInput != 0) {
            playerRigidBody.velocity = new Vector2(horizontalInput*speed, playerRigidBody.velocity.y)  ;
        }

        if (!isLogWritten) {
            for (int i = 0; i < 10; i++) {
                Debug.Log("i: " + i);
            }
            isLogWritten = true;
        }
        

        //playerRigidBody.AddForce(new Vector2(, 0));  
        //playerRigidBody.velocity = new Vector2(horizontalInput*speed, verticalInput*speed);  
    }
}
