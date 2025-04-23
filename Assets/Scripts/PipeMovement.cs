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
    public Sprite birdDead;
    public float recoilForce = 50f;

    private AudioManager audioManager;
    public AudioClip jumpSFX;
    public AudioClip deathSFX;


    private void Awake()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();
    }

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
            audioManager.PlaySFX(jumpSFX);
        }
        if (myRigidBody.velocity.y < -40f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,-40f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // 2D Collider, no trigger
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("Hit with the boundary");
            myRigidBody.AddForce(new Vector2(0, Mathf.Sign(myRigidBody.velocity.y) * recoilForce), ForceMode2D.Impulse);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bird"))
        {
            BirdDeath(collision);
            audioManager.PlaySFX(deathSFX);
            logicScript.gameOver();
            myRigidBody.gravityScale = 0;
            myRigidBody.velocity = Vector2.zero;
            isBirdAlive = false;
        }
    }

    private void BirdDeath(Collision2D collision)
    {
        GameObject bird = collision.gameObject;
        Animator birdAnimator = bird.GetComponent<Animator>();
        if (birdAnimator != null)
        {
            birdAnimator.enabled = false;
        }

        SpriteRenderer birdSpriteRenderer = bird.GetComponent<SpriteRenderer>();
        if (birdSpriteRenderer != null)
        {
            birdSpriteRenderer.sprite = birdDead;
        }

        Rigidbody2D birdRigidBody = bird.GetComponent<Rigidbody2D>();
        if (birdRigidBody != null)
        {
            birdRigidBody.constraints = RigidbodyConstraints2D.None;
            birdRigidBody.gravityScale = gravityScale;
        }
    }
}