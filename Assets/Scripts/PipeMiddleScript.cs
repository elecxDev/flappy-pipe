using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int scoreToAdd = 1;
        if (collision.gameObject.layer == 3)
        {
            logicScript.addScore(scoreToAdd);
        }
    }
}