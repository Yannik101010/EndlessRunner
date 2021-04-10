using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private string injump = "n";
    private string laneChange = "n";

    public static Vector3 playerPos;
    private int speed = 3;
    public static int shield = 0;

    void Start()
    {
        // Getting the rigidbody to influence velocity and setting the speed
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }
    

    void Update()
    {
        // Getter for current player position
        playerPos = transform.position;
        //movement left and right
        //if Player is not jumping and not inbetween lanes and not under -0.9 on the x-axis his velocity is changed -1 in x direction
        //lane change is changed to yes and coroutine is started to set velocity back to 0
        if ((Input.GetKey("a")) && (laneChange == "n") && (transform.position.x > -1) && (injump == "n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, speed);
            laneChange = "y";
            StartCoroutine(stopLaneChange());
        }
        //same as above for the other direction
        if ((Input.GetKey("d")) && (laneChange =="n" && (transform.position.x < 1)) && (injump == "n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, speed);
            laneChange = "y";
            StartCoroutine(stopLaneChange());
        }

        //Jumping when not currently in jump or between lanes
        //velocity is changed and couroutine is called to bring player back to ground
        if (Input.GetKey("space") && (injump == "n") && (laneChange == "n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, speed);
            injump = "y";
            StartCoroutine(stopJump());  
        }
    }
    //velocity is changed back to 0 after 1 second to ensure player is roughly always at 1, 0 or -1
    IEnumerator stopLaneChange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        laneChange = "n";
    }
    // velocity is changed to -1.5 to ensure player comes back down and then again to 0 to player is on ground
    //WaitForSeconds ensures the change of velocity does not happen emidiatly 
    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.5f, speed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        injump = "n";
    }
   
    // For collision with objects, shield = 1 means shield equipped, shield = 0 means collision with object destroyed shield
    // If shield is equipped and collision occurs it is set back to no shield (shield = 0)
    // Player cannot collect shields, only 1 shield at a time can be used
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shield")
        {
            shield = 1;
        }
        if (other.tag == "obstacle" && shield == 0)
        {
            Destroy(gameObject);
            uiManager.destroyed = true;
        }
        if (other.tag == "obstacle" && shield == 1)
        {
            shield = 0;
        }
    }

}
