using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] ParticleSystem granadeExplosion;
    [SerializeField] float timeToExplode = 2f;
    [SerializeField] int radius = 5;
    [SerializeField] int damage = 100;
    [SerializeField] int force = 200;
    [SerializeField] AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GranadeExplosion());
    }

    // Update is called once per frame
    private IEnumerator GranadeExplosion()
    {

   
        yield  return new  WaitForSeconds(timeToExplode);
        if (explosion)
            AudioSource.PlayClipAtPoint(explosion, transform.position,.01f);
        Destroy(Instantiate(granadeExplosion, transform.position, Quaternion.identity), .5f);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in colliders)
        {

            Health h = c.GetComponent<Health>();
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (h)  //damage target
            {
                h.Hit(damage);
            }
            if (rb) //move target
            {
                rb.AddExplosionForce(force, transform.position, radius,0.5f,ForceMode.Impulse);
            }

        }
        yield return new WaitForSeconds(.5f);

        Destroy(gameObject);

    }
   
}
