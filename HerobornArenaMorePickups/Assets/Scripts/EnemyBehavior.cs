using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private static SphereCollider sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Get the BoxCollider component attached to the cube
        sphereCollider = GetComponent<SphereCollider>();
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player")) // Make sure your player has the "Player" tag
        {
            GameBehavior.detected = "DETECTED";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameBehavior.detected = "HIDDEN";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public static void ShrinkCollider()
    {
        if (sphereCollider != null)
        {
            // Get the current radius of the SphereCollider
            float currentRadius = sphereCollider.radius;

            // Shrink the radius by half
            sphereCollider.radius = currentRadius * 0.5f;

            // Optionally, log to confirm the size change
            Debug.Log("Enemy Detection Radius Halved!");
        }
        else
        {
            Debug.LogError("SphereCollider component not found!");
        }
    }
}
