using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] public Gradient gradient;
    [SerializeField] public Image fill;
    [SerializeField] ParticleSystem bloodEffect;


    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int health = 100;
    private bool alive = true;

    private void Start()
    {
        SetNaxHealth(maxHealth);
    }
    public void Hit(int damage)
    {
        if (health - damage < 0)
            health = 0;
        else
            health -= damage;
        UpdateHealthBar();

        if (health <= 0 && alive)
        {
            alive = false;
            GetComponent<Character>().OnDeath();
        }
                
    }

    internal void Bleed(Vector3 pos)
    {
        Destroy(Instantiate(bloodEffect, pos , Quaternion.LookRotation(pos.normalized)), .5f);
    }

    private void SetNaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    private void UpdateHealthBar()
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);


    }

    public bool isAlive()
    {
        return health >0;
    }
}
