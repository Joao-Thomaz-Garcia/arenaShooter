using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnstoppableEnemy : EnemyClass
{
    //Enemy Status
    [SerializeField]
    float enemyHealth = 100f;
    [SerializeField]
    float enemySpeed = 30f;
    [SerializeField]
    float enemyDamage = 2f;

    //Dash Properties
    float chargingTimer;
    [SerializeField]
    float chargingTimerUpdate = 1.5f;
    [SerializeField]
    int dashAmount = 2;
    int dashesDone = 0;

    Vector3 waypoint = Vector3.zero;

    [SerializeField] LayerMask layerMask;
    [SerializeField] LayerMask wallMask;

    NavMeshAgent agent;

    EnemyStatesType state;

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

        if (!(GetPlayerObject() != null))
        {
            Debug.Log("ERROR NONE PLAYER OBJECT SET UPON THIS ENEMY");
            SetHealth(0);
        }

    }

    private void FixedUpdate()
    {
        while (state == EnemyStatesType.Chase)
        {
            PrepareToDash();

            break;
        }
        while (state == EnemyStatesType.Dashing)
        {
            Dash();

            break;
        }
        while (state == EnemyStatesType.Attack)
        {
            GetPlayerObject().GetComponent<DamageTaker>().TakeDamage(GetDamage(), Vector3.zero, null);
            state = EnemyStatesType.Chase;

            break;
        }

    }

    void PrepareToDash()
    {
        agent.SetDestination(transform.position);

        chargingTimer += Time.fixedDeltaTime;
        if (chargingTimer >= chargingTimerUpdate)
        {
            if(dashesDone < dashAmount)
            {
                waypoint = SetupDashPosition();
                state = EnemyStatesType.Dashing;
                dashesDone++;
            }
            else
            {
                chargingTimer = 0;
                dashesDone = 0;
            }
        }

    }

    Vector3 SetupDashPosition()
    {
        Vector3 playerPosition = new Vector3(GetPlayerObject().transform.position.x, transform.position.y , GetPlayerObject().transform.position.z);

        Vector3 lookAtThis = transform.position - playerPosition;
        lookAtThis.Normalize();
        lookAtThis = -lookAtThis;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, lookAtThis, out hit, Mathf.Infinity, wallMask))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green, 2f);

            return (hit.point);
        }
        else
        {
            return transform.position;
        }
    }

    void Dash()
    {
        if(Vector3.Distance(transform.position, waypoint) <= 1f)
            state = EnemyStatesType.Chase;

        agent.SetDestination(waypoint);

    }

    private void OnDrawGizmos()
    {
        //Gizmos da aréa de detecção do player.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 15f);

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer != layerMask && state == EnemyStatesType.Dashing)
            state = EnemyStatesType.Attack;

    }
}

