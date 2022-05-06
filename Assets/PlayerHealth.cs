using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float atualHealth;


    private void Start()
    {
        atualHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        print("ENTROU NO SET HEALTH!");
        atualHealth -= health;

        if (atualHealth <= 0)
        {
            print("ENTROU NO IF!");
            Destroy(gameObject);
        }
    }


}
