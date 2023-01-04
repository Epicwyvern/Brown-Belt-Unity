using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = 1;

        Vector3 destination = new Vector3(horizontal, 0, vertical);
        transform.Translate(destination * speed * Time.deltaTime);
    }
}
