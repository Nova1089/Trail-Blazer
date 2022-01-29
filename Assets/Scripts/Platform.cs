using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // configs
    [SerializeField] float distanceBeforeDestroy = 100f;

    // cache
    Transform player;

    // Unity messages
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (GetDistanceFromPlayer() > distanceBeforeDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    float GetDistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}
