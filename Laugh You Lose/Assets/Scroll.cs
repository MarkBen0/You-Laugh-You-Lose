using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //https://www.youtube.com/watch?v=P3hcopOkpa8
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private float width;
    //private float speed = GameManager.Instance.speed;
    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x * 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            Reposition();
        }
        rb.velocityX = -GameManager.Instance.speed;
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}