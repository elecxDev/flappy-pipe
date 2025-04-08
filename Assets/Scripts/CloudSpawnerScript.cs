using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject[] cloudPrefabs; // Assign c1 to c5 prefabs
    private float spawnRate = 2f;
    private float heightRange = 20f;
    private float timer = 0f;
    public LogicScript logicScript;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SpawnCloud();
    }

    void Update()
    {
        if (!logicScript.isGameOver)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnCloud();
                timer = 0f;
            }
        }
    }

    void SpawnCloud()
    {
        int randIndex = Random.Range(0, cloudPrefabs.Length);
        float yOffset = Random.Range(-heightRange, heightRange);

        Instantiate(
            cloudPrefabs[randIndex],
            new Vector3(transform.position.x, transform.position.y + yOffset, 0),
            Quaternion.identity
        );
    }
}
