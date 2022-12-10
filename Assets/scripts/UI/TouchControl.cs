using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;

public class TouchControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] OnScreenButton sprint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnPointerUp(PointerEventData data)
    {
        sprint.GetComponent<ButtonPress>().OnPress(false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        sprint.GetComponent<ButtonPress>().OnPress(true);
    }
}
