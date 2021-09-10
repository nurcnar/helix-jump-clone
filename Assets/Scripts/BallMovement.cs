using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private bool ignoreNextCollision; 
    Rigidbody rb;
    bool onAir = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (onAir)
        {
            Vector3 vel = rb.velocity;
            vel.y -= 45 * Time.fixedDeltaTime;
            rb.velocity = vel;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sector"))
        {
            if(collision.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                GameManager.instance.GameOver();
            }
        }
        if (ignoreNextCollision)
            return;
        onAir = false;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * 800f);
        onAir = true;
        ignoreNextCollision = true;
        Invoke("ChangeBool", .2f);
    }
    private void ChangeBool()
    {
        ignoreNextCollision = false;
    }
}