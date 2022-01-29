using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    // configs
    [SerializeField] float distanceUnderPlayer = 30f;

    // cache
    Transform player;

    // Unity messages
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter(Collider otherCollider) 
    {
        SceneManager.LoadScene(0);
    }

    // private methods
    void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, -distanceUnderPlayer, player.position.z);
        transform.position = targetPosition;
    }
}
