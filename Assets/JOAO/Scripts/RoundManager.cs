using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    float CircleRadius = 4.5f;
    List<GameObject> spawnedEnemys = new List<GameObject>();

    [SerializeField]
    int amountOfEnemys = 5;

    private void Start()
    {
        SpawnEnemys(amountOfEnemys);
    }

    private void SpawnEnemys(int amountToSpawn)
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            Vector3 SpawnPoint = Random.insideUnitSphere * CircleRadius;
            SpawnPoint += transform.position;
            SpawnPoint.y = 0.75f;

            var enemyManager = GetComponent<EnemyManager>();
            var groundEnemy = enemyManager.GroundShooterEnemy;
            var playerObject = enemyManager.GetPlayerObject();

            GameObject go = Instantiate(groundEnemy, SpawnPoint, Quaternion.identity);
            go.name = i.ToString();
            go.GetComponent<EnemyClass>().SetPlayerObject(playerObject);
            spawnedEnemys.Add(go);

        }
        


    }

    private void OnDrawGizmos()
    {
        //Spawn Range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, CircleRadius);

        /*
        Gizmos.color = Color.blue;
        for (int i = 0; i < 5; i++)
        {
            Gizmos.DrawWireSphere(spawnPositions[i], .5f);
        }*/
    }
}
