using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StandardEnemy : EnemyClass
{

    Vector3 waypoint;
//

    bool playerIsVisible = false;

    [SerializeField]LayerMask layerMask;

    float timer;
    float timerUpdate = 40f;

    GameObject playerObject;

    NavMeshAgent agent;

    EnemyStatesType state;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStatesType.Innactive;

        SetHealth(15);
        SetSpeed(8);
        SetDamage(1);

        agent.speed = GetSpeed();

        //Acho que pesaria muito atribuir a posição do jogador no Awake, porque teriamos que procurar em todos os objetos da cena.
        //Essa chamada seria pesada devido a quantia de inimigos.


        //MoveAgent();
    }


    private void Update()
    {
        while(state == EnemyStatesType.Innactive)
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
        while (state == EnemyStatesType.Chase)
        {
            Chase();

            break;
        }
        while (state == EnemyStatesType.Attack)
        {
            //Do Damage
            break;
        }

    }

    void Chase()
    {
        if(Vector3.Distance(transform.position, playerObject.transform.position) > 20f)
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
            if(timer != 0)
                timer = 0;

            agent.SetDestination(playerObject.transform.position);
        }



    }
    
    /*Vector3 FindDirection()
    {
        Vector3 newDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        newDir.Normalize();
    
    //FOR COM PROBLEMA, PODE SER REMOVIDO
        for (int i = 0; i >= 1;)
        {
            newDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            newDir.Normalize();

            if (newDir != GetDirection())
            {
                i++;
                return newDir;
            }
        }
    
        waypoint = (newDir * 10f) + transform.position;
        return newDir;
    }*/


    private void OnDrawGizmos()
    {
        /* 
        //Gizmos da direção definida.
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(waypoint, .5f);*/


        //Gizmos da aréa de detecção do player.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 15f);

    }
}
