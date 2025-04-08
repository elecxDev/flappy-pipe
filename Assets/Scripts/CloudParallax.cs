using UnityEngine;

public class CloudParallax : MonoBehaviour
{
    public float baseSpeed = 1f;
    private float moveSpeed;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        SetPropertiesByTag();
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Loop cloud when it goes off screen (you can tweak this range)
        if (transform.position.x < -30f)
        {
            transform.position = new Vector3(30f, startPos.y, startPos.z);
        }
    }

    void SetPropertiesByTag()
    {
        switch (gameObject.tag)
        {
            case "c1":
                transform.localScale = new Vector3(10f, 10f, 10f);
                moveSpeed = baseSpeed * 1.0f;
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;
            case "c2":
                transform.localScale = new Vector3(12f, 12f, 10f);
                moveSpeed = baseSpeed * 1.2f;
                transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
                break;
            case "c3":
                transform.localScale = new Vector3(6f, 6f, 10f);
                moveSpeed = baseSpeed * 0.4f;
                transform.position = new Vector3(transform.position.x, transform.position.y, 2f);
                break;
            case "c4":
                transform.localScale = new Vector3(7f, 7f, 10f);
                moveSpeed = baseSpeed * 0.6f;
                transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
                break;
            case "c5":
                transform.localScale = new Vector3(9f, 9f, 10f);
                moveSpeed = baseSpeed * 0.9f;
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
                break;
            default:
                transform.localScale = new Vector3(10f, 10f, 10f);
                moveSpeed = baseSpeed;
                break;
        }
    }
}
