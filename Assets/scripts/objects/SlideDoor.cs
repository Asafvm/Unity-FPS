using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("isOpen", other.gameObject.layer == LayerMask.NameToLayer("Humanoid"));
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("isOpen", false);
    }

    public void OnSlideDoorOpen()
    {
        GetComponent<AudioSource>().Play();
    }
    public void OnSlideDoorClose()
    {
        GetComponent<AudioSource>().Play();
    }
}
