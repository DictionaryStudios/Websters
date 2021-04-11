using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // ranged or melee weapon
    // 0 for melee
    // 1 for ranged
    public int weaponType;
    // weapon equipped
    // ranged weapon list:
    // 0 for pistol
    // melee weapon list:
    // 0 for knife
    public int weapon;
    // ranged weapon stats
    public float ranged_damage;
    public float range;
    public float rate_of_fire;
    public int clip_size;
    public int max_ammo_size;
    // melee weapon stats
    public int speed;
    public int melee_damage;

}
