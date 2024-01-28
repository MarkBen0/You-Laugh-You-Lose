using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComicBook : MonoBehaviour
{
    public AudioClip contactSound; // Assign your sound clip in the Inspector
    private AudioSource audioSource;
    public int scoreValue = 10;
    public TextMeshProUGUI totalScoreText;
    public float movementSpeed = 2f;
    private void Start()
    {

        ScoreManager.Initialize(totalScoreText);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = contactSound;
    }
    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Update()
    {
        float movementDistance = movementSpeed * Time.deltaTime;

        // Move the object in the negative x-direction
        transform.Translate(Vector3.left * movementDistance);
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
            ScoreManager.AddScore(10);
        }
    }

    void DeactivateGameObject()
    {
        // Deactivate the entire GameObject after a delay if needed
        gameObject.SetActive(false);
    }
}
