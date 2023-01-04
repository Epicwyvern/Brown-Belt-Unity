using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject door;
    public int target;
    private int count;

    // Update is called once per frame
    void Start()
    {
        count = 0;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            count++;
        }

        if (count >= target) {
            Destroy(door);
        }
    }
}
