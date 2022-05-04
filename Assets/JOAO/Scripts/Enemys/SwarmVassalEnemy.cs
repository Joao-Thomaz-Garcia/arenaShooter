using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SwarmVassalEnemy : EnemyClass
{
    //SAME AS GROUND SHOOTER ENEMY//
    float timer;
    float timerUpdate = 40f;

    EnemyStatesType state;

    NavMeshAgent agent;

    //INDIVIDUAL PROPERTIES//
    SwarmLeaderEnemy swarmLeader;

    GameObject playerObject;

    Vector3 positionToHold;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Chase;
    }

    private void Update()
    {
        CheckHealth();

    }

    private void FixedUpdate()
    {
        if (agent.speed != GetSpeed())
            agent.speed = GetSpeed();

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

    }

    public void SetSwarmLeader(SwarmLeaderEnemy swarmLeader)
    {
        this.swarmLeader = swarmLeader;

    }
    public void SetPositionToHold(Vector3 positionToHold)
    {
        this.positionToHold = positionToHold;

    }
    public void SetPlayerObject(GameObject playerObject)
    {
        this.playerObject = playerObject;
    }


    public Vector3 GetPositionToHold()
    {
        return positionToHold;
    }




    private void CheckStates()
    {
        if (swarmLeader != null)
        {
            Vector3 vassalPositionToHold = swarmLeader.transform.position + (positionToHold * 2f);

            if(Vector3.Distance(transform.position, vassalPositionToHold) >= 1.5f)
            {
                state = EnemyStatesType.Chase;

            }
            else if (Vector3.Distance(transform.position, playerObject.transform.position) < 10f && Vector3.Distance(transform.position, vassalPositionToHold) < 1.5f)
            {
                state = EnemyStatesType.Attack;

            }
        }
        else
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
    }

    private void Chase()
    {
        if (swarmLeader != null)
            agent.SetDestination(swarmLeader.transform.position + (positionToHold * 2f));

        else
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
            Destroy(gameObject);
        }
    }
}
