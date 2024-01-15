using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusicController : MonoBehaviour
{
    GameObject pausemusic;
   public void PlayMusic()
    {
        pausemusic.SetActive(true);
    }
}
