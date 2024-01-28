using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    private AudioSource audioSource;
    private bool isMoving = false;
    // Start is called before the first frame update
    private bool isTripping = false;
    public float tripDuration = 1f;
    public float tripRotationSpeed = 360f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move sideways
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        bool newIsMoving = Mathf.Abs(horizontalInput) > 0.1f;
        // Jump
        UpdateFootstepSound(newIsMoving);

        isMoving = newIsMoving;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void UpdateFootstepSound(bool isPlayerMoving)
    {
        if (isPlayerMoving && !isMoving)
        {
            PlayFootstepSound();
        }
        else if (!isPlayerMoving && isMoving && audioSource.isPlaying)
        {
            StopFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        // Check if the audio source is not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    void StopFootstepSound()
    {
        // Stop the footstep sound
        audioSource.Stop();
    }

    void Jump()
    {
        // Perform a simple jump by adding force in the upward direction
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("-10");
        }
        if (other.CompareTag("Obstacle") && !isTripping)
        {
            // Start the tripping coroutine
            StartCoroutine(Trip());
        }
    }
    IEnumerator Trip()
    {
        isTripping = true;

        float originalRotationSpeed = tripRotationSpeed;

        // Gradually rotate the player during the trip
        float targetRotation = transform.eulerAngles.z + 180f; // Rotate 180 degrees
        while (transform.eulerAngles.z < targetRotation)
        {
            float rotationStep = tripRotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationStep);
            yield return null;
        }

        yield return new WaitForSeconds(tripDuration);

        // End of trip effect or adjustments
        transform.rotation = Quaternion.identity;
        tripRotationSpeed = originalRotationSpeed;

        isTripping = false;
    }
}

