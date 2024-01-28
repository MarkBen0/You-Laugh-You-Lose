using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Water : MonoBehaviour
{
    public int scoreValue = -10;
    public TextMeshProUGUI totalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Initialize(totalScoreText);
    }

    public TextMeshProUGUI scoreText;

    private int score = 0;
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Renderer renderer = GetComponent<Renderer>();
        Collider2D collider = GetComponent<Collider2D>();

        if (collider != null && collider.isTrigger) // Check if collider is a trigger
        {

            // If you want to disable the entire GameObject after a delay, you can use Invoke
            ScoreManager.AddScore(-10);
            Debug.Log("Damage");
        }
    }
    
}
