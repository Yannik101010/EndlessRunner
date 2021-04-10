using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanUp : MonoBehaviour
{
    void Start()
    {
        
    }

    // Deletes objects this script is attached to if distance to player is < 40 
    // avoids lagging and getting the game to crowded
    void Update()
    {
        if (transform.position.z < player.playerPos.z - 40)
        {
            Destroy(gameObject);
        }
    }
}