using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void SS()
    {
        SceneManager.LoadScene("SSMenu");
    }
    public void PC()
    {
        SceneManager.LoadScene("PCMenu");
    }
    public void PW()
    {
        SceneManager.LoadScene("PWMenu");
    }
    public void GW()
    {
        SceneManager.LoadScene("GWMenu");
    }
}
