using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField] ParticleSystem missEffect;
    [SerializeField] GameObject bulletHole;
    [SerializeField] private int damage = 10;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    private void OnParticleCollision(GameObject collision)
    {

        int events = GetComponent<ParticleSystem>().GetCollisionEvents(collision, colEvents);
        Health h = collision.gameObject.GetComponent<Health>();
        for (int i = 0; i < events; i++)
        {
            if (h)
            {
                h.Bleed(colEvents[i].intersection);
                h.Hit(Mathf.RoundToInt( damage * Random.Range(0.7f,1.2f))); //base damage * random factor
            }
            else
            {
                Destroy(Instantiate(missEffect, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal)), .5f);
            }

            Debug.Log($"Shot {collision.gameObject.name}: {h} : at {colEvents[i].intersection}");

        }

    }
}
