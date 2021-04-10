using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    // Plays Run animation
    void Start()
    {
        GetComponent<Animator>().Play("Run");
    }
    void Update()
    {
        
    }
}
