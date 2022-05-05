using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    private float health;
    private float speed;
    private float damage;

    private GameObject playerObject;


    //Sets
    public void SetHealth(float health)
    {
        this.health = health;
        if (health <= 0)
            Destroy(gameObject);
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public void SetPlayerObject(GameObject playerObject)
    {
        this.playerObject = playerObject;
    }

    public void TakeDamage(float damage)
    {
        float newHealth = (health - damage);
        health = newHealth;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
    public GameObject GetPlayerObject()
    {
        return playerObject;
    }

}
