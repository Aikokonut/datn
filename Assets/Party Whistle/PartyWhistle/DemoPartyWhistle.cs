using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class DemoPartyWhistle : MonoBehaviour
{
    [SerializeField]
    private Material mat;

    [SerializeField]
    private Texture2D[] texture;

    [SerializeField]
    private int currentTexture = -1;

    private void Update()
    {
#if UNITY_EDITOR
        SyncData();
#endif
    }

    private void SyncData()
    {
        if (mat!=null && currentTexture >0 && currentTexture < texture.Length)
        {
            mat.mainTexture = texture[currentTexture];
        }
    }
}
