using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WingTest : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Initialize(totalScoreText);
    }

    // Update is called once per frame
    public Transform centerPoint;
    public int scoreValue = 10;
    public float rotationSpeed = 400f; // Adjust the rotation speed as needed
    float radius = 2.0f; // Adjust the radius as needed

    public TextMeshProUGUI scoreText;

    private int score = 0;

    public float movementSpeed = 1f;

    void Update()
    {
        float movementDistance = movementSpeed * Time.deltaTime;

        // Move the object in the negative x-direction
        transform.Translate(Vector3.left * movementDistance);
    }

    void FixedUpdate()
    {
        //Debug.Log("Update is called!");
        //float angle = rotationSpeed * Time.fixedDeltaTime;
        Vector3 offset = new Vector3(0f, 0f, rotationSpeed); //* radius;
        //transform.position = transform.position + offset;
        transform.eulerAngles = transform.eulerAngles + offset;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            Debug.Log("collected");
        }
    }

    void Collect()
    {
        Renderer renderer = GetComponent<Renderer>();
        Collider2D collider = GetComponent<Collider2D>();

        if (collider != null && collider.isTrigger) // Check if collider is a trigger
        {
            if (renderer != null)
                renderer.enabled = false;

            if (collider != null)
                collider.enabled = false;

            // If you want to disable the entire GameObject after a delay, you can use Invoke
            Invoke("DeactivateGameObject", 1f);
            ScoreManager.AddScore(10);
        }
    }

    void DeactivateGameObject()
    {
        // Deactivate the entire GameObject after a delay if needed
        gameObject.SetActive(false);
    }
    
}
