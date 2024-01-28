using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Water : MonoBehaviour
{
    public AudioClip contactSound; // Assign your sound clip in the Inspector
    private AudioSource audioSource;
    public int scoreValue = -10;
    public TextMeshProUGUI totalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Initialize(totalScoreText);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = contactSound;
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
            PlayContactSound();
            ScoreManager.AddScore(-5);
            Debug.Log("Damage");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("StopContactSound", 1f);
        }
    }
    void PlayContactSound()
    {
        if (audioSource != null && contactSound != null)
        {
            audioSource.PlayOneShot(contactSound);
        }
    }
    void StopContactSound()
    {
        // Stop the audio playback
        audioSource.Stop();
    }
}
