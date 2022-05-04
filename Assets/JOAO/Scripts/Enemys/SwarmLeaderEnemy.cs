using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SwarmLeaderEnemy : EnemyClass
{
    [SerializeField]
    float vassalSpeed = 5f;
    [SerializeField]
    float vassalHealth = 15f;

    bool HasSpawned = false;

    float timer;
    float timerUpdate = 40f;

    NavMeshAgent agent;

    EnemyStatesType state;

    [SerializeField] LayerMask layerMask;

    [SerializeField]
    GameObject vassalGameObject;
    [SerializeField]
    GameObject[] vassalList = new GameObject[4];

    GameObject playerObject;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Innactive;

        SetHealth(25);
        SetSpeed(5);
        SetDamage(3);

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

        if((state != EnemyStatesType.Innactive) && !HasSpawned)
        {
            agent.speed = GetSpeed();

            SpawnSwarm();
            HasSpawned = true;
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
        while (Vector3.Distance(transform.position, playerObject.transform.position) >= 12f)
        {
            state = EnemyStatesType.Chase;

            break;
        }
        while (Vector3.Distance(transform.position, playerObject.transform.position) < 12f)
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

        Debug.DrawLine(transform.position, playerObject.transform.position, Color.red);
    }


    private void SpawnSwarm()
    {
        for (int i = 0; i <= 3; i++)
        {
            GameObject go = Instantiate(vassalGameObject, transform.position, Quaternion.identity);
            SwarmVassalEnemy swarmVassal = go.GetComponent<SwarmVassalEnemy>();

            swarmVassal.SetSwarmLeader(this);
            swarmVassal.SetSpeed(vassalSpeed);
            swarmVassal.SetHealth(vassalHealth);

            swarmVassal.SetPlayerObject(playerObject);
            go.GetComponent<DamageTaker>().SetHitPopUp(GetComponent<DamageTaker>().GetHitPopUp());

            if (i == 0)
            {
                swarmVassal.SetPositionToHold(transform.right);

                go.transform.position = (transform.position + (swarmVassal.GetPositionToHold() * 2f));
            }
            if (i == 1)
            {
                swarmVassal.SetPositionToHold(-transform.right);

                go.transform.position = (transform.position + (swarmVassal.GetPositionToHold() * 2f));
            }
            if (i == 2)
            {
                swarmVassal.SetPositionToHold(transform.forward);

                go.transform.position = (transform.position + (swarmVassal.GetPositionToHold() * 2f));
            }
            if (i == 3)
            {
                swarmVassal.SetPositionToHold(-transform.forward);

                go.transform.position = (transform.position + (swarmVassal.GetPositionToHold() * 2f));
            }

            vassalList[i] = go;
        }
    }


    private void CheckHealth()
    {
        if (GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
