using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private WeaponSystem WeaponsManager;
    public GameObject startpoint; 
    //start and end points for bullet direction vector
    private GameObject bullet;

    // Awake is called before start
    void Awake()
    {
        WeaponsManager = GetComponentInParent<WeaponSystem>();
        bullet = Resources.Load("bullet") as GameObject;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && WeaponsManager.weaponType == 1)
        {
            StartCoroutine(waitabit());
        }

        if (Input.GetButtonDown("Fire1") && WeaponsManager.weaponType == 0)
        {
            meleeAttack();
        }
    }

    void fireRangedWeapon()
    {
        Debug.Log("fire");
        // direction to shoot bullet
        Vector3 direction = startpoint.transform.position;
        GameObject clone;
        clone = Instantiate(bullet, startpoint.transform.position, startpoint.transform.rotation);
        Bullet bulletScript = clone.GetComponent<Bullet>();
        bulletScript.bulletDamage = WeaponsManager.ranged_damage;
        Rigidbody clonerb = clone.GetComponent<Rigidbody>();
        clonerb.AddForce(startpoint.transform.forward * 50, ForceMode.Impulse);

    }

    void meleeAttack()
    {
        Debug.Log("melee");
    }

    IEnumerator waitabit()
    {
        fireRangedWeapon();
        yield return new WaitForSeconds(1);
    }
}
