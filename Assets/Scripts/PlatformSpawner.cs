using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // configs
    [SerializeField] GameObject[] platforms;
    [SerializeField] GameObject hazard;
    [SerializeField] float spawnDistanceFromPlayer = 20f;
    [SerializeField] int maxXDistanceFromLastEndPoint = 2;
    [SerializeField] int maxYDistanceFromLastEndPoint = 2;
    [SerializeField] int percentChanceToSpawnFireworks = 10;

    // state
    GameObject lastSpawnedPlatform;
    Transform player;

    // Unity messages
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Start()
    {
        SpawnInitialPlatform();
    }

    void Update()
    {
        if (IsPlayerCloseToEnd())
        {
            Transform platformInstance = SpawnRandomPlatform();
            if (TriggeredChanceToSpawnHazard())
            {
                SpawnHazard(platformInstance);
            }
        }
    }

    // private methods
    void SpawnInitialPlatform()
    {
        int randomPlatform = Random.Range(0, platforms.Length);
        GameObject platformInstance = Instantiate(platforms[randomPlatform], transform.position, Quaternion.identity, this.transform);
        lastSpawnedPlatform = platformInstance;
    }

    bool IsPlayerCloseToEnd()
    {
        if (lastSpawnedPlatform == null) return false;
        Vector3 endOfLastPlatform = lastSpawnedPlatform.GetComponentInChildren<EndPoint>().transform.position;
        return Vector3.Distance(player.position, endOfLastPlatform) <= spawnDistanceFromPlayer;
    }
    
    Transform SpawnRandomPlatform()
    {
        int randomPlatform = Random.Range(0, platforms.Length);        
   
        Vector3 endOfLastPlatform = lastSpawnedPlatform.GetComponentInChildren<EndPoint>().transform.position;

        int randomX = Random.Range((int)endOfLastPlatform.x + 1, 
            (int)endOfLastPlatform.x + maxXDistanceFromLastEndPoint);

        int randomY = Random.Range((int)endOfLastPlatform.y - maxYDistanceFromLastEndPoint, 
            (int)endOfLastPlatform.y + maxYDistanceFromLastEndPoint);

        Vector3 spawnLocation = new Vector3(randomX, randomY, endOfLastPlatform.z);   
   
        GameObject platformInstance = Instantiate(platforms[randomPlatform], spawnLocation, Quaternion.identity, this.transform);
        lastSpawnedPlatform = platformInstance;
        return platformInstance.transform;
    }

    bool TriggeredChanceToSpawnHazard()
    {
        int diceRoll = Random.Range(1, 101);

        if (diceRoll <= percentChanceToSpawnFireworks)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Transform SelectRandomChild(Transform parent)
    {
        int index = Random.Range(0, parent.childCount);
        return parent.GetChild(index);
    }

    private void SpawnHazard(Transform platformInstance)
    {
        GameObject fireworksInstance = Instantiate(hazard, SelectRandomChild(platformInstance));
    }
} 
