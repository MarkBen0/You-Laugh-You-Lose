using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] gameObjects;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.GetComponent<Rigidbody2D>().velocityX = -speed;
        }
    }
}
