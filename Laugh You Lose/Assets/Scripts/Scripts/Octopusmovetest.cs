using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Octopusmovetest : MonoBehaviour
{
    public AudioClip contactSound; // Assign your sound clip in the Inspector
    private AudioSource audioSource;
    public float movementSpeed = 100f;
    public int scoreValue = -30;
    public TextMeshProUGUI totalScoreText;

    void Start()
    {
        // Invoke the MoveTurtle method every 2 seconds, starting after 2 seconds
        ScoreManager.Initialize(totalScoreText);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = contactSound;
        InvokeRepeating("MoveOctopus", 2f,2f);
    }
    public TextMeshProUGUI scoreText;
    private int score = 0;
    void MoveOctopus()
    {
        // Add your movement logic here
        // For simplicity, let's move the turtle in the positive x-direction
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayContactSound();
            Collect();
            Debug.Log("collected");
        }
    }
    void PlayContactSound()
    {
        if (audioSource != null && contactSound != null)
        {
            audioSource.PlayOneShot(contactSound);
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
            ScoreManager.AddScore(-30);
        }
    }

    void DeactivateGameObject()
    {
        // Deactivate the entire GameObject after a delay if needed
        gameObject.SetActive(false);
    }
}
