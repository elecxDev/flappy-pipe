using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    
    public Rigidbody2D myRigidBody;
    public float jumpForce = 5f;
    public float gravityScale = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.gravityScale = gravityScale;
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        myRigidBody.velocity = Vector2.up * jumpForce;
    }
}
