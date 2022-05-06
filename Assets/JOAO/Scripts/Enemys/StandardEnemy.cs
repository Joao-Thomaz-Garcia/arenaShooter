using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StandardEnemy : EnemyClass
{
    //Enemy Status
    [SerializeField]
    float enemyHealth = 100f;
    [SerializeField]
    float enemySpeed = 5f;
    [SerializeField]
    float enemyDamage = 2f;


    [SerializeField] LayerMask layerMask;

    NavMeshAgent agent;

    EnemyStatesType state;
    private void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Chase;

        SetHealth(enemyHealth);
        SetSpeed(enemySpeed);
        SetDamage(enemyDamage);

        agent.speed = GetSpeed();
        if (GetPlayerObject() != null)
            Chase();
        else
        {
            Debug.Log("ERROR NONE PLAYER OBJECT SET UPON THIS ENEMY");
            SetHealth(0);


        }
    }

    private void FixedUpdate()
    {
        while (state == EnemyStatesType.Chase)
        {
            Chase();

            break;
        }
        while (state == EnemyStatesType.Attack)
        {
            //GetPlayerObject().GetComponent<DamageTaker>().TakeDamage(GetDamage(), Vector3.zero, null);

            //Do Damage
            break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != layerMask)
            state = EnemyStatesType.Attack;

    }

    void Chase()
    {

        agent.SetDestination(playerObject.transform.position);
    }

}
