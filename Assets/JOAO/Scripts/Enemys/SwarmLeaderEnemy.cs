using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SwarmLeaderEnemy : EnemyClass
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
    float shotDelay = 1f;
    [SerializeField]
    float shotDistance = 20f;

    //Vassal Status
    [SerializeField]
    float vassalSpeed = 5f;
    [SerializeField]
    float vassalHealth = 15f;

    //Vassal Shoot Properties
    [SerializeField]
    float vassalShotDelay = 2f;
    [SerializeField]
    float vassalShotDistance = 10f;

    [SerializeField]
    GameObject shotProjectile;

    //REMOVER APÓS CORREÇÕES DO PREFAB -> NÃO DEIXAR ELE DESTRUIR O PRÓPRIO ATIRADOR.
    [SerializeField]
    GameObject shotAim;

    bool HasSpawned = false;

    float timer;
    float timerUpdate = 40f;

    NavMeshAgent agent;

    EnemyStatesType state;

    [SerializeField]
    GameObject vassalGameObject;
    [SerializeField]
    GameObject[] vassalList = new GameObject[4];

    [SerializeField]
    GameObject playerObject;
    private void Start()
    {
        //Temporario.
        SetPlayerObject(playerObject);

        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Chase;

        SetHealth(enemyHealth);
        SetSpeed(enemySpeed);
        SetDamage(enemyDamage);

        agent.speed = GetSpeed();

        if (!HasSpawned)
        {
            SpawnSwarm();
            HasSpawned = true;
        }


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
        while (Vector3.Distance(transform.position, GetPlayerObject().transform.position) >= 12f)
        {
            state = EnemyStatesType.Chase;

            break;
        }
        while (Vector3.Distance(transform.position, GetPlayerObject().transform.position) < 12f)
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
        if (shotTimer >= shotDelay)
        {
            Instantiate(shotProjectile, shotAim.transform.position, shotAim.transform.rotation);
            Debug.DrawLine(transform.position, GetPlayerObject().transform.position, Color.red, 1f);

            shotTimer = 0;
        }

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
            swarmVassal.SetVassalShotDelay(vassalShotDelay);
            swarmVassal.SetVassalShotDistance(vassalShotDistance);

            swarmVassal.SetShotProjectile(shotProjectile);

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
    public float GetShotDistance()
    {
        return shotDistance;
    }
}
