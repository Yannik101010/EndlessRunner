using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Move the camera alongside our player
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
    }

    // stop moving if our player is destroyed
    void Update()
    {
        if (uiManager.destroyed)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
