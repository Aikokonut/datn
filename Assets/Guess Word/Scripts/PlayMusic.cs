using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour
{
    public Silder silder;
    public GameObject playmusic;
    public GameObject pausemusic;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PLaySound);
    }
    void PLaySound()
    {

        silder.PlayMusic();
        playmusic.SetActive(false);
        pausemusic.SetActive(true);
    }
}
