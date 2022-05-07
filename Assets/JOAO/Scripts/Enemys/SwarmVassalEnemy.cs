using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SwarmVassalEnemy : EnemyClass
{
    //Shoot Properties
    float shotTimer;
    float shotDelay = 2f;
    float shotDistance = 10f;

    GameObject shotProjectile;

    [SerializeField]
    GameObject shotAim;

    EnemyStatesType state;

    NavMeshAgent agent;


    SwarmLeaderEnemy swarmLeader;

    Vector3 positionToHold;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Chase;

        var playerObject = swarmLeader.GetPlayerObject();
        SetPlayerObject(playerObject);

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
            else if (Vector3.Distance(transform.position, GetPlayerObject().transform.position) < swarmLeader.GetShotDistance() && Vector3.Distance(transform.position, vassalPositionToHold) < 1.5f)
            {
                state = EnemyStatesType.Attack;

            }
        }
        else
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
    }

    private void Chase()
    {
        if (swarmLeader != null)
            agent.SetDestination(swarmLeader.transform.position + (positionToHold * 2f));

        else
        {
            agent.SetDestination(transform.position);

        }
    }
    protected override void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(GetPlayerObject().transform.position);

        shotTimer += Time.fixedDeltaTime;
        if (shotTimer >= shotDelay)
        {
            /// COMENTEI MESMO! FODA-SE! SE FUDEU PARA DESCOBRIR O MOTIVO DO CARA NÃO ESTAR ATIRANDO...
            ProjectileController _projectile = Instantiate(shotProjectile, shotAim.transform.position, shotAim.transform.rotation).GetComponent<ProjectileController>();
            _projectile.ActivateEnemyProjectile(shotAim.transform);
            Debug.DrawLine(transform.position, GetPlayerObject().transform.position, Color.red, 1f);

            shotTimer = 0;
        }
    }


    public void SetShotProjectile(GameObject shotProjectile)
    {
        this.shotProjectile = shotProjectile;
    }
    public void SetVassalShotDelay(float shotDelay)
    {
        this.shotDelay = shotDelay;
    }
    public void SetVassalShotDistance(float shotDistance)
    {
        this.shotDistance = shotDistance;
    }
}
