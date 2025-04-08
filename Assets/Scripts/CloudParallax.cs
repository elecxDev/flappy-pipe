using UnityEngine;

public class CloudParallax : MonoBehaviour
{
    private float moveSpeed;

    void Start()
    {
        SetPropertiesByTag();
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Despawn when off screen
        if (transform.position.x < -60f)
        {
            Destroy(gameObject);
        }
    }

    void SetPropertiesByTag()
    {
        switch (gameObject.tag)
        {
            case "c1":
                transform.localScale = new Vector3(15f, 15f, 10f);
                moveSpeed = 5f;
                transform.position += new Vector3(0f, 0f, 0f);
                break;
            case "c2":
                transform.localScale = new Vector3(17f, 17f, 10f);
                moveSpeed = 4.5f;
                transform.position += new Vector3(0f, 0f, -1f);
                break;
            case "c3":
                transform.localScale = new Vector3(11f, 11f, 10f);
                moveSpeed = 2f;
                transform.position += new Vector3(0f, 0f, 2f);
                break;
            case "c4":
                transform.localScale = new Vector3(12f, 12f, 10f);
                moveSpeed = 2.5f;
                transform.position += new Vector3(0f, 0f, 1.5f);
                break;
            case "c5":
                transform.localScale = new Vector3(14f, 14f, 10f);
                moveSpeed = 3.5f;
                transform.position += new Vector3(0f, 0f, 0.5f);
                break;
            default:
                transform.localScale = new Vector3(15f, 15f, 10f);
                moveSpeed = 3f;
                break;
        }

        // Slight speed randomizer for variation
        moveSpeed *= Random.Range(1.5f, 2.5f);
    }
}
