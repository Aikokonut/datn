using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    float wait = 2f;
    [SerializeField]
    public GameObject[] OB;
    [SerializeField]
    private int random = -1;
    public GameObject bomb;
    public bool boomTime = false;
    private int count;
    private float waitTime;

    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            count++;
            Debug.Log("Count" + count);
            yield return new WaitForSeconds(waitTime);
        }
    }
    void Update()
    {
        UpdateRandomIndex();
        if (count >= 1 && count <= 5)
            {
                boomTime = false;
                waitTime = 3.0f;
            }
            else if (count > 5 && count <= 10)
            {
                boomTime = false;
                waitTime = 2f;
            }
            else if (count > 10 && count <= 15)
            {
                boomTime = false;
                waitTime = 1.5f;
            }
            else if (count > 15 && count <= 20)
            {
                boomTime = true;
                waitTime = 1f;
            }
            else if (count > 20 && count <= 30)
            {
                boomTime = true;
                waitTime = 0.8f;
            }
            else
            {
                boomTime = true;
                waitTime = 0.5f;
            }
    }
    public void SpawnObject()
    {
        GameObject prefabToSpawn;
        prefabToSpawn = GetRandomObject();
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(Random.Range(-2, 2), 4, 0), Quaternion.identity);
        Debug.Log("waitime" + waitTime);
        StartCoroutine(FallWithSpeed(spawnedObject, waitTime));
    }
    IEnumerator FallWithSpeed(GameObject obj, float waitTime)
    {
        while (true)
        {
            if (obj == null)
            {
                yield break;
            }
            obj.transform.Translate(Vector3.down * Time.deltaTime);
            yield return null;
        }
    }
    void UpdateRandomIndex()
    {
            random = Random.Range(0, OB.Length);
    }
    public void Fall()
    {
        GameObject selectedObject = GetRandomObject();
        Instantiate(selectedObject, new Vector3(Random.Range(-2, 2), 4, 0), Quaternion.identity);
    }
    public GameObject GetRandomObject()
    {
        if (!boomTime)
        {
            return OB[random];
        }
        else
        {
            int randomIndex = Random.Range(0, OB.Length + 1); // Adjusted range
            return randomIndex == OB.Length ? bomb : OB[randomIndex];
        }
    }
}
