using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : MonoBehaviour
{
    public AudioSource source;
    public AudiLoundControl detector;
    public Animator animator;
    public Vector3 minScale;
    public Vector3 maxScale;
    public float loundSen = 100;
    public float threshold = 0.1f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float loundless = detector.GetLoudFromMicro() * loundSen;
        if (loundless > 1)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        Debug.Log("lound" + loundless);
    }
}

