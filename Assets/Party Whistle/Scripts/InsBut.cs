using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsBut : MonoBehaviour
{
    public GameObject instructionPanel;
    [SerializeField] GameObject pauseMenu;
    void Start()
    {
        Button closeButton = GetComponent<Button>();
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
    }
    public void ClosePanel()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }
    }
    public void OpenPanel()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("PWPlay");
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("PWMenu");
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
