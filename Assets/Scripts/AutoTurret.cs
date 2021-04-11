using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public GameObject startpoint;
    private GameObject endpoint;
    //start and end points for bullet direction vector
    private Vector3 direction;

    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate top gun part between min and max degrees horizontally
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            endpoint = collider.gameObject;
            direction = endpoint.transform.position - startpoint.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            //when object enters area create vecotor from turret to object and shoot projectile using existing code
        }
    }

    public void Takedamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

}
