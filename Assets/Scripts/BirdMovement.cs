using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public PipeMovement pipeScript;
    public float moveSpeed = 1f;
    public float deadZone = +45;
    public LogicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logicScript.isGameOver)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x >= deadZone)
        {
            Bird();
        }
    }

    void destroyBird()
    {
        Destroy(gameObject);
    }
}