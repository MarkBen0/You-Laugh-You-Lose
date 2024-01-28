using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Reset the position to the respawn point
        transform.position = respawnPoint.position;
    }
}