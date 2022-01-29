using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceIndicatorUI : MonoBehaviour
{
    // cache
    Text textComponent;
    Transform player;

    void Awake()
    {
        textComponent = GetComponentInChildren<Text>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        int playerX = (int)player.position.x;
        textComponent.text = playerX.ToString();
    }
}
