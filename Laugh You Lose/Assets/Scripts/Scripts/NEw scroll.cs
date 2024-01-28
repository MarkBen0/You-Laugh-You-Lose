using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScroll: MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private float width;
    public float speed; // Adjust the speed in the Inspector

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x * transform.localScale.x;
    }

    void Update()
    {
        if (transform.position.x < -width)
        {
            Reposition();
        }

        rb.velocity = new Vector2(-GameManager.Instance.speed, 0f);
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}