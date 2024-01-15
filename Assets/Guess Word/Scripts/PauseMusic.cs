using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMusic : MonoBehaviour
{

    public Silder silder;
    public GameObject playmusic;
    public GameObject pausemusic;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PauseSound);
    } 
    void PauseSound()
    {
        silder.PauseMusic();
        playmusic.SetActive(true);
        pausemusic.SetActive(false);
    }
}
