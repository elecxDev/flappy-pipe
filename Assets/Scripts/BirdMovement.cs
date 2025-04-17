using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float flapAmplitude = 10f; // how high it bobs
    public float flapFrequency = 2f; // how fast it bobs
    public float deadZone = +45;
    public LogicScript logicScript;

    private float startY;
    private float timeAlive;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        startY = transform.position.y;
        timeAlive = 0f;
    }

    void Update()
    {
        if (!logicScript.isGameOver)
        {
            // Move right
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            // Flap (bobbing motion)
            timeAlive += Time.deltaTime;
            float newY = startY + Mathf.Sin(timeAlive * flapFrequency) * flapAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        if (transform.position.x >= deadZone)
        {
            destroyBird();
        }
    }

    void destroyBird()
    {
        Destroy(gameObject);
    }
}
