using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    void Start()
    {
        int objectIndex = PlayerPrefs.GetInt("ObjectToSpawn", 0);
        Debug.Log("Object Index: " + objectIndex);
        if (objectIndex >= 0 && objectIndex < objectsToSpawn.Length)
        {
            Instantiate(objectsToSpawn[objectIndex], transform.position, Quaternion.identity);
        }
    }
}
