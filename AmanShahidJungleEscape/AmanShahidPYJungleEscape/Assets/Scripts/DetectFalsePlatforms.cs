using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{   
    bool hit;
    int falseLayer = 1 << 8; 

    void Update()
    {

        hit = Physics.Raycast(transform.position, transform.forward, 3, falseLayer);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);

        if (hit) {
            Debug.LogWarning("Be Careful!");
        } else {
            Debug.Log("All Clear!");
        }

    }
}
