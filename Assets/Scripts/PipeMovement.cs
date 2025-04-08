using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public LogicScript logicScript;
    public Rigidbody2D myRigidBody;
    private float jumpForce = 20f;
    private float gravityScale = 4.9f;
    public bool isBirdAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.gravityScale = 0;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            myRigidBody.velocity = Vector2.up * jumpForce;
            myRigidBody.gravityScale = gravityScale;
        }
        if (myRigidBody.velocity.y < -40f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,-40f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
        myRigidBody.gravityScale = 0;
        myRigidBody.velocity = Vector2.zero;
        isBirdAlive = false;
    }
}