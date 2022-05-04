using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnstoppableEnemy : EnemyClass
{
    Vector3 waypoint = Vector3.zero;
    bool playerIsVisible = false;

    [SerializeField] LayerMask layerMask;
    [SerializeField] LayerMask wallMask;


    float chargingTimer;
    float chargingTimerUpdate = 1.5f;

    float timer;
    float timerUpdate = 40f;

    GameObject playerObject;

    NavMeshAgent agent;

    EnemyStatesType state;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Innactive;

        SetHealth(30);
        SetSpeed(30f);
        SetDamage(5);


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

                agent.speed = GetSpeed();
                state = EnemyStatesType.Chase;
            }

            break;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SetupDashPosition();
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
            //Do Damage
            break;
        }

    }

    void PrepareToDash()
    {
        //Dar um dash na direção do jogador, mas só parar na parede
        //

        chargingTimer += Time.fixedDeltaTime;
        if (chargingTimer >= chargingTimerUpdate)
        {
            waypoint = SetupDashPosition();

            chargingTimer = 0;
            state = EnemyStatesType.Dashing;
        }

    }

    Vector3 SetupDashPosition()
    {
        Vector3 playerPosition = new Vector3(playerObject.transform.position.x, transform.position.y ,playerObject.transform.position.z);

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
        if(Vector3.Distance(transform.position, waypoint) <= 0.5f)
            state = EnemyStatesType.Chase;

        agent.SetDestination(waypoint);

    }

    private void CheckHealth()
    {
        if (GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnDrawGizmos()
    {

        //Gizmos da aréa de detecção do player.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 15f);

    }
}

