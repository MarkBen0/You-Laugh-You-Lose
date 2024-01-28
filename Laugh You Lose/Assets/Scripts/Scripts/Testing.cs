using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Testing : MonoBehaviour
{
    public int scoreValue = -10;
    public TextMeshProUGUI totalScoreText;
    public float movementSpeed = 2f;
    public float tripDuration = 2f; // Adjust the duration of the trip
    public AudioClip contactSound; // Assign your sound clip in the Inspector

    private AudioSource audioSource;
    private bool isTripping = false;

    private void Start()
    {
        ScoreManager.Initialize(totalScoreText);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = contactSound;
    }

    private void Update()
    {
        if (!isTripping)
        {
            float movementDistance = movementSpeed * Time.deltaTime;

            // Move the object in the negative x-direction
            transform.Translate(Vector3.left * movementDistance);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTripping)
        {
            PlayContactSound();
            Collect();
            Debug.Log("collected");

            // Start the trip coroutine
            StartCoroutine(Trip());
        }
    }

    private IEnumerator Trip()
    {
        isTripping = true;

        // Trip effect or adjustments (e.g., alter movement during tripping)
        float originalSpeed = movementSpeed;
        movementSpeed = 0.5f; // Adjust as needed

        yield return new WaitForSeconds(tripDuration);

        // End of trip effect or adjustments
        movementSpeed = originalSpeed;

        isTripping = false;
    }

    private void PlayContactSound()
    {
        if (audioSource != null && contactSound != null)
        {
            audioSource.PlayOneShot(contactSound);
        }
    }

    private void Collect()
    {
        Renderer renderer = GetComponent<Renderer>();
        Collider2D collider = GetComponent<Collider2D>();

        if (collider != null && collider.isTrigger)
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

    private void DeactivateGameObject()
    {
        // Deactivate the entire GameObject after a delay if needed
        gameObject.SetActive(false);
    }
}
