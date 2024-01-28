using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isMoving = false;
    private bool isTripping = false;
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    public float tripDuration = 4f;
    public float tripRotationSpeed = 360f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Move sideways
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        bool newIsMoving = Mathf.Abs(horizontalInput) > 0.1f;
        UpdateFootstepSound(newIsMoving);

        isMoving = newIsMoving;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check for obstacles and start tripping
        if (CheckForObstacle() && !isTripping)
        {
            StartCoroutine(Trip());
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
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool CheckForObstacle()
    {
        // Raycast down to check for obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null && hit.collider.CompareTag("Obstacle");
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
