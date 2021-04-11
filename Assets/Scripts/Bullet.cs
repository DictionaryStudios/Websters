using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletLifeTimer;       // stores time since bullet spawned
    private float bulletLifeDuration = 4f;   // time before bullet is destroyed
    public float bulletDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletLifeTimer = bulletLifeDuration;     // when bullet spawns the time before the bullet dies is set
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTimer -= Time.deltaTime;       // As time passes the bullet life time is decreasing
        if ( bulletLifeTimer <= 0 )      // Destroy bullet when its time runs out
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Explosive")
        {
            Destroy (other.gameObject);
            Collider[] collidersHit = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider item in collidersHit)
            {
                if (item.gameObject.tag == "Destructable")
                {
                    Destroy(item.gameObject);
                }
            }
        }

        if (other.gameObject.tag == "Turret")
        {
            other.gameObject.GetComponentInChildren<AutoTurret>().Takedamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
