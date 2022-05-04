using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    private float health;
    private float speed;
    private float damage;

    //Sets
    public void SetHealth(float health)
    {
        this.health = health;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    //Gets
    public float GetHealth()
    {
        return health;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public float GetDamage()
    {
        return damage;
    }

}
