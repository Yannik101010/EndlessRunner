using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    void Start()
    {
        // velocity of y axis is 5 to let coin spin
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
    }
    void Update()
    {
        
    }
    // when player collects coin, 1 coin is added and collected coin is destroyed
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            uiManager.coins += 1;
            Destroy(this.gameObject);
        }
    }
}
