using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] Sprite defaulImage;
    [SerializeField] Sprite pressedImage;

    public void OnPress(bool press)
    {
        GetComponent<Image>().sprite = press ? pressedImage : defaulImage;
    }
}
