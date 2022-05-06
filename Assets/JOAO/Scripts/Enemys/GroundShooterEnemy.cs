using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GroundShooterEnemy : EnemyClass
{
    //Enemy Status
    [SerializeField]
    float enemyHealth = 100f;
    [SerializeField]
    float enemySpeed = 5f;
    [SerializeField]
    float enemyDamage = 2f;

    //Shoot Properties
    float shotTimer;
    [SerializeField]
    float shotDelay = 2f;
    [SerializeField]
    float shotDistance = 10f;

    [SerializeField]
    GameObject shotProjectile;

    //REMOVER APÓS CORREÇÕES DO PREFAB -> NÃO DEIXAR ELE DESTRUIR O PRÓPRIO ATIRADOR.
    [SerializeField]
    GameObject shotAim;

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


        if(GetPlayerObject() != null)
            Chase();
        else
        {
            Debug.Log("ERROR NONE PLAYER OBJECT SET UPON THIS ENEMY");
            SetHealth(0);
        }
    }
    private void FixedUpdate()
    {
        while (!(state == EnemyStatesType.Innactive))
        {
            CheckStates();

            while (state == EnemyStatesType.Chase)
            {
                Chase();
                break;
            }
            while (state == EnemyStatesType.Attack)
            {
                Attack();
                break;
            }

            break;
        }
    }

    private void CheckStates()
    {
        while (Vector3.Distance(transform.position, GetPlayerObject().transform.position) >= shotDistance)
        {
            state = EnemyStatesType.Chase;

            break;
        }
        while (Vector3.Distance(transform.position, GetPlayerObject().transform.position) < shotDistance)
        {

            state = EnemyStatesType.Attack;

            break;
        }
    }

    private void Chase()
    {
        agent.SetDestination(GetPlayerObject().transform.position);


    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(GetPlayerObject().transform.position);

        shotTimer += Time.fixedDeltaTime;
        if(shotTimer >= shotDelay)
        {
            /// COMENTEI MESMO! FODA-SE! SE FUDEU PARA DESCOBRIR O MOTIVO DO CARA NÃO ESTAR ATIRANDO...
            //Instantiate(shotProjectile, shotAim.transform.position, shotAim.transform.rotation);
            Debug.DrawLine(transform.position, GetPlayerObject().transform.position, Color.red, 1f);

            shotTimer = 0;
        }


    }
}
