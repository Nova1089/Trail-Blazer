using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    // configs
    [SerializeField] GameObject cloudGroup;
    [SerializeField] float lengthOfCloudGroup = 140f;

    // cache
    Transform currentCloudGroup;
    Transform oldCloudGroup;

    // Unity messages
    void Start()
    {
        SpawnFirstCloudGroup();
    }

    void OnTriggerEnter(Collider other)
    {
        if (oldCloudGroup != null)
        {
            Destroy(oldCloudGroup.gameObject);
        }
        SpawnNewCloudGroup();
    }

    // private methods
    void SpawnFirstCloudGroup()
    {
        GameObject instance = Instantiate(cloudGroup, Vector3.zero, Quaternion.identity, this.transform);
        currentCloudGroup = instance.transform;
    }

    private void SpawnNewCloudGroup()
    {        
        Vector3 newPosition = new Vector3(currentCloudGroup.position.x + lengthOfCloudGroup, 0, 0);
        GameObject instance = Instantiate(cloudGroup, newPosition, Quaternion.identity, this.transform);
        oldCloudGroup = currentCloudGroup;
        currentCloudGroup = instance.transform;
    }
}
