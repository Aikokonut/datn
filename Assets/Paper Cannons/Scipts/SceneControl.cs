using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void ButtonPressed(int objectIndex)
    {
        PlayerPrefs.SetInt("ObjectToSpawn", objectIndex);
        SceneManager.LoadScene("PCPlay");
    }
    public void Back()
    {
        SceneManager.LoadScene("PCMenu");
    }
}

