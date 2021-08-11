using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float fireDelay;
    [SerializeField] ParticleSystem gunEffect;
    [SerializeField] ParticleSystem bulletEffect;


    public void Fire(Transform target)
    {
        AudioSource gunShot = GetComponent<AudioSource>();
        if (gunShot)
            gunShot.Play();
        if (gunEffect)
            gunEffect.Play();
        if (bulletEffect)
            bulletEffect.Play();
    }

}
