using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject == player)
            Teleport();
    }

    void Teleport()
    {
        player.transform.position = destination.position;
    }
}
