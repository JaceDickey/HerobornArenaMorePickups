using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        // 2                 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
     }
    // 1
    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            // 3
            Destroy(this.transform.parent.gameObject);

            // 4
            Debug.Log("Stamina doubled!");
        }
        PlayerBehavior.redStaminaPickedUp();
    }
}