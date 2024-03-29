using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Testing : MonoBehaviour
{
    public AudioClip contactSound; // Assign your sound clip in the Inspector
    private AudioSource audioSource;
    public int scoreValue = -10;
    public TextMeshProUGUI totalScoreText;
    private Rigidbody2D rb;
    //public float movementSpeed = 2f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = contactSound;
        ScoreManager.Initialize(totalScoreText);
        rb = GetComponent<Rigidbody2D>();
    }
    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Update()
    {
        //float movementDistance = GameManager.Instance.speed * Time.deltaTime;

        // Move the object in the negative x-direction
        //transform.Translate(Vector3.left * movementDistance);
        rb.velocityX = -GameManager.Instance.speed;
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
            ScoreManager.AddScore(-10);
        }
    }

    void DeactivateGameObject()
    {
        // Deactivate the entire GameObject after a delay if needed
        gameObject.SetActive(false);
    }
}
