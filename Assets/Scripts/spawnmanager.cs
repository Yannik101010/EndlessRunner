using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    // for ground to spawn
    [SerializeField]
    private Transform environment;
    private Vector3 nextEnvironmentSpawn;

    // randomizer to randomize object spawning
    private int x_randomizer;
    private int z_randomizer;

    //ground spawn
    [SerializeField]
    private Transform ground;
    private Vector3 nextGroundSpawn;

    //different objects
    [SerializeField]
    private Transform rocksObj;
    private Vector3 nextRockSpawn;

    [SerializeField]
    private Transform coinObj;
    private Vector3 nextCoinSpawn;

    [SerializeField]
    private Transform crateObj;
    private Vector3 nextCrateSpawn;

    [SerializeField]
    private Transform bigObstacleObj;
    private Vector3 nextBigObstacleSpawn;

    [SerializeField]
    private Transform shieldObj;
    private Vector3 nextshieldSpawn;

    private int timer;
    private int timer2;
    void Start()
    {
        //next ground at 88
        nextEnvironmentSpawn.z = 88;
        nextGroundSpawn.z = 84;
        //starting functions to spawn ground and objects
        StartCoroutine(spawnEvironment());
        StartCoroutine(spawnGroundAndObjects());
    }

    void Update()
    {
        
    }

    //ground spawning
    IEnumerator spawnEvironment()
    {
        //wait for 11 seconds so spawning is not faster or slower than player movement 
        yield return new WaitForSeconds(11);
        Instantiate(environment, nextEnvironmentSpawn, environment.rotation);
        //next ground is spawned 44 more of the z axis
        nextEnvironmentSpawn.z += 44;
        //spawning is repeated as long as player is not destroyed
        if (uiManager.destroyed)
        {
            StopCoroutine(spawnEvironment());
        }
        else
        {
            StartCoroutine(spawnEvironment());
        }
    }
    //object and ground spawning
    IEnumerator spawnGroundAndObjects()
    {
        yield return new WaitForSeconds(3);
        //randomize x and z position and spawn at a certain distance from the player
        z_randomizer = Random.Range(45, 50);
        x_randomizer = Random.Range(-1, 2);
        nextCoinSpawn.z = player.playerPos.z + z_randomizer;
        nextCoinSpawn.x = x_randomizer;
        nextCoinSpawn.y = 0.5f;
        Instantiate(coinObj, nextCoinSpawn, coinObj.rotation);

        //spawn obstacle at next ground spawn
        x_randomizer = Random.Range(-1, 2);
        nextRockSpawn = nextGroundSpawn;
        nextRockSpawn.x = x_randomizer;
        nextRockSpawn.y = -0.4f;
        Instantiate(ground, nextGroundSpawn, ground.rotation);
        Instantiate(rocksObj, nextRockSpawn, rocksObj.rotation);
        nextGroundSpawn.z += 4;
        
        //spawn only one crate an one rock on one ground (to ensure not all paths are blocked or they spawn directly behind each other)
        x_randomizer = Random.Range(-1, 2);
        nextCrateSpawn = nextGroundSpawn;
        nextCrateSpawn.x = x_randomizer;
        nextCrateSpawn.y = 0;
        Instantiate(ground, nextGroundSpawn, ground.rotation);
        Instantiate(crateObj, nextCrateSpawn, crateObj.rotation);
        nextGroundSpawn.z += 4;

        //only spawn new shields if the player has no shield at the moment, also set to a timer for not having to many shields
        if (player.shield == 0 && timer == 8)
        {
            x_randomizer = Random.Range(-1, 2);
            nextshieldSpawn.z = nextGroundSpawn.z +2;
            nextshieldSpawn.x = x_randomizer;
            nextshieldSpawn.y = 0.5f;
            Instantiate(shieldObj, nextshieldSpawn, shieldObj.rotation);
            timer = 0;
        }
        //not jumpable object set on a timer for easier game, spawns togehter with crate and rock
        if (timer2 == 5)
        {
            x_randomizer = Random.Range(-1, 2);
            nextBigObstacleSpawn = nextGroundSpawn;
            nextBigObstacleSpawn.x = x_randomizer;
            nextBigObstacleSpawn.y = -0.5f;
            Instantiate(ground, nextGroundSpawn, ground.rotation);
            Instantiate(bigObstacleObj, nextBigObstacleSpawn, bigObstacleObj.rotation);
            timer2 = 0;
        }
        //increasing timer for shield and big obstacle every iteration
        timer += 1;
        timer2 += 1;

        //object spawning is repeated as long as player is not destroyed
        if (uiManager.destroyed)
        {
            StopCoroutine(spawnGroundAndObjects());
        }
        else
        {
            StartCoroutine(spawnGroundAndObjects());
        }
    }
}