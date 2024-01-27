using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Ray2D ray;
    private Rigidbody2D rb;
    [SerializeField] private float Thrust;
    [SerializeField] private float JumpRay;
    [SerializeField] private float JumpGravity;
    private float NormalGravity;
    [SerializeField] private LayerMask floorLayer;
    Collider2D floor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        NormalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray2D(transform.position, -transform.up);
        
        bool CanJump = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), JumpRay, floorLayer);

        if (Input.GetButtonDown("Jump") && CanJump)
        {
            //rb.AddForce(transform.up * m_Thrust);
            rb.velocityY = Thrust;
        }
        bool IsFalling = rb.velocityY < 0;
        if (Input.GetButton("Jump") && IsFalling)
        {
            rb.gravityScale = JumpGravity;
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = NormalGravity;
        }
    }
}
