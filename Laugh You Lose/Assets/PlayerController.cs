using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Ray2D ray;
    private Rigidbody2D rb;
    public float m_Thrust = 20f;
    public float JumpRay = 100f;
    public LayerMask floorLayer;
    Collider2D floor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray2D(transform.position, -transform.up);
        
        bool CanJump = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), JumpRay, floorLayer);
        if(CanJump)
        {
            Debug.Log("here");
        }
        if (Input.GetButtonDown("Jump") && CanJump)
        {
            //rb.AddForce(transform.up * m_Thrust);
            rb.velocityY = m_Thrust;
        }
    }
}
