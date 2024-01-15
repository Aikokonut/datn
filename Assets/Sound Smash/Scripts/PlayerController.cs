using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private float speed = 0.2f;
    private Rigidbody2D rb;
    private Touch touch;
    public Text timer;
    private bool isDying = false;
    private float startTime;
    public GameObject p1;
    public GameObject p2;
    public GameObject functionbut;
    bool isGameOver = false;
    public GameObject die;
    private FinalScore FN;
    public event Action PlayerDied;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartGame();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchDeltaPosition = new Vector3(touch.deltaPosition.x, 0, 0);
                transform.Translate(touchDeltaPosition * speed * Time.deltaTime);
            }
        }
    }
    void StartGame()
    {
        startTime = Time.time;
        StartCoroutine(UpdateTime());
    }
    IEnumerator UpdateTime()
    {
        while (!isDying)
        {
            float elapsedTime = Time.time - startTime;
            string timerString = FormatTime(elapsedTime);
            if (timer != null)
            {
                timer.text = timerString;
            }
            yield return null;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            FallingObject fallingObject = collision.gameObject.GetComponent<FallingObject>();
            p1.SetActive(false);
            p2.SetActive(true);
            StartCoroutine(ResetStatesAfterDelay());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bom"))
        {
            Died();
            Time.timeScale = 0;
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            isGameOver = true;
        }
    }
    IEnumerator ResetStatesAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        p1.SetActive(true);
        p2.SetActive(false);
    }



    public void Died()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            if (PlayerDied != null)
            {
                PlayerDied();
            }
        }
        functionbut.SetActive(false);
        die.SetActive(true);
    }
    string FormatTime(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}

