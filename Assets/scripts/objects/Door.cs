using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AudioClip doorClose;
    [SerializeField] AudioClip doorOpen;
    [SerializeField] AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
            GetComponentInParent<Animator>().SetBool("isOpen", other.gameObject.layer == LayerMask.NameToLayer("Humanoid"));   
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("isOpen", false);
    }

    public void OnDoorOpen()
    {
        source.clip = doorOpen;
        source.Play();
    }
    public void OnDoorClose()
    {
        source.clip = doorClose;
        source.Play();
    }
}
