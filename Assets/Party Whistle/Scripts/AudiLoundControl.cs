using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiLoundControl : MonoBehaviour
{
    public int sample = 64;
    private AudioClip microphoneClip;
    void Start()
    {
        MicroToAudio();
    }

    void Update()
    {

    }
    public void MicroToAudio()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }
    public float GetLoudFromMicro()
    {
        return GetLoudFromAudio(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudFromAudio(int clipPosition, AudioClip clip)
    {
        int startpos = clipPosition - sample;
        if (startpos < 0)
        {
            return 0;
        }
        float[] wavedata = new float[sample];
        clip.GetData(wavedata, startpos);
        float totalLoundess = 0;
        for (int i = 0; i < sample; i++)
        {
            totalLoundess += Mathf.Abs(wavedata[i]);
        }
        return totalLoundess; ;
    }
}

