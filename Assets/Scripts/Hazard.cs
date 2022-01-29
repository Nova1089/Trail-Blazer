using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        SceneManager.LoadScene(0);
    }
}
