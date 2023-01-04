using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float jumpForce;
    public bool canJump;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.y > -0.1 && rigidbody.velocity.y <.01) {
            canJump = true;
        } else {
            canJump = false;
        }

        if (canJump && Input.GetButtonDown("Jump")) {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
