using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContro : MonoBehaviour
{
    public int objectIndex;

    void Start()
    {
        // Lắng nghe sự kiện khi nút được ấn
        GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        SceneControl sceneController = FindObjectOfType<SceneControl>();

        sceneController.ButtonPressed(objectIndex);

    }
}
