using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grounded"))
        
            Teleport();
    }

    void Teleport()
    {
        player.transform.position = destination.position;
    }
}
