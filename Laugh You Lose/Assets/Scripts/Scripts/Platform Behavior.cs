using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public int scoreValue = 10; // The score added when collected
    public float movementSpeed = 1.5f;

    void Update()
    {
        float movementDistance = movementSpeed * Time.deltaTime;

        // Move the object in the negative x-direction
        transform.Translate(Vector3.left * movementDistance);
    }
}
