using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public Scene chooseScene;
    public void Loading()
    {
        SceneManager.LoadScene("");
    }
}
