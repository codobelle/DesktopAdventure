using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public AudioClip TeleportationClip;
    private AudioSource source;
    public Transform destination;
    public GameObject player;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        source.PlayOneShot(TeleportationClip, 0.7F);
        if (other.gameObject.CompareTag("Grounded"))
        
            Teleport();
    }

    void Teleport()
    {
        player.transform.position = destination.position;
    }
}
