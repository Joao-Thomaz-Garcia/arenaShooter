using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GroundShooterEnemy : EnemyClass
{

    float timer;
    float timerUpdate = 40f;

    NavMeshAgent agent;

    EnemyStatesType state;

    [SerializeField] LayerMask layerMask;

    GameObject playerObject;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Innactive;

        SetHealth(5);
        SetSpeed(5);
        SetDamage(2);

        agent.speed = GetSpeed();

    }

    private void Update()
    {
        CheckHealth();
        while (state == EnemyStatesType.Innactive)
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, 15f, layerMask);
            if (collider.Length != 0)
            {
                playerObject = collider[0].gameObject;

                agent.SetDestination(playerObject.transform.position);

                state = EnemyStatesType.Chase;
            }

            break;
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
        while (Vector3.Distance(transform.position, playerObject.transform.position) >= 10f)
        {
            state = EnemyStatesType.Chase;

            break;
        }
        while (Vector3.Distance(transform.position, playerObject.transform.position) < 10f)
        {

            state = EnemyStatesType.Attack;

            break;
        }
    }

    private void Chase()
    {
        if (Vector3.Distance(transform.position, playerObject.transform.position) > 40f)
        {
            //Se estiver afastado do jogador, ficar parado na mesma posição
            agent.SetDestination(transform.position);

            //Caso o jogador saia de perto do inimigo por muito tempo, destruir o objeto.
            timer += Time.fixedDeltaTime;
            if (timer >= timerUpdate)
            {
                //Destruir objeto.

                timer = 0;
            }
        }
        else
        {
            if (timer != 0)
                timer = 0;

            agent.SetDestination(playerObject.transform.position);
        }

    }

    private void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(playerObject.transform.position);

        Debug.DrawLine(transform.position, playerObject.transform.position);
    }

    private void CheckHealth()
    {
        if (GetHealth() <= 0)
        {
            print(gameObject.name + " reached 0 HP");
            Destroy(gameObject);
        }
    }
}
