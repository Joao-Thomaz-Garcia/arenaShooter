using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float atualHealth;


    private void Start()
    {
        atualHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        atualHealth = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
