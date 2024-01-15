using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    public int point = 10;
    public AudioClip collisionSound;
    private AudioSource audioSource;

    private Dictionary<string, int> objectPoints = new Dictionary<string, int>();
    public Text scoreText;

    public GameObject[] objectPrefabs; // Mảng chứa prefab của các vật thể

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string objectName = gameObject.name;

            if (!objectPoints.ContainsKey(objectName))
            {
                objectPoints.Add(objectName, 0);
            }

            FinalScore.instance.AddPoint();
            objectPoints[objectName]++;


            if (collisionSound != null)
            {
                audioSource.clip = collisionSound;
                audioSource.Play();
                Invoke("TurnOffSound", 1f);
            }
        }
    }
    private void TurnOffSound()
    {
        audioSource.Stop();
        Destroy(gameObject);
    }
}
