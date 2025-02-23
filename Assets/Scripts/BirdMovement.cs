using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public LogicScript logicScript;
    public Rigidbody2D myRigidBody;
    public float jumpForce = 5f;
    public float gravityScale = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.gravityScale = gravityScale;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        myRigidBody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
    }
}
