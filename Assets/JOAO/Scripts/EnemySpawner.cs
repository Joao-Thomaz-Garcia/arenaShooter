using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Criar um contador de spawns realizados?

    int EnemyInList = 0;

    [SerializeField]
    int amountOfEnemys = 5;

    [SerializeField]
    float spawnTimerUpdate = 2f;
    float timer;

    [SerializeField]
    float CircleRadius = 4.5f;



    List<GameObject> spawnedEnemys = new List<GameObject>();
    List<float> spawnedEnemysHealth = new List<float>();

    private void FixedUpdate()
    {
        SpawnTimer();

    }


    private void SpawnTimer()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= spawnTimerUpdate)
        {
            SpawnEnemys(amountOfEnemys);
            timer = 0;
        }
        else if(timer != 0 && spawnedEnemys.Count == 0)
        {
            SpawnEnemys(amountOfEnemys);
            timer = 0;
        }
    }
    //Setar por Scriptable Object.
    //Decidir qual inimigo spawnar pelo Scriptable Object também.
    private void SpawnEnemys(int amountToSpawn)
    {
        for(int i = 0; i <= amountToSpawn; i++)
        {
            Vector3 SpawnPoint = Random.insideUnitSphere * CircleRadius;
            SpawnPoint += transform.position;
            SpawnPoint.y = 0.75f;

            var enemyManager = GetComponent<EnemyManager>();
            var playerObject = enemyManager.GetPlayerObject();
            var enemyListCount = enemyManager.EnemysList.Count;

            EnemyInList = Random.Range(0, enemyListCount);

            var enemyFromList = enemyManager.EnemysList[EnemyInList];

            GameObject go = Instantiate(enemyFromList, SpawnPoint, Quaternion.identity);
            spawnedEnemys.Add(go);

            var manageEnemyClass = go.GetComponent<EnemyClass>();
            var enemyHealth = manageEnemyClass.GetHealth();

            spawnedEnemysHealth.Add(enemyHealth);

            manageEnemyClass.SetPlayerObject(playerObject);



        }


    }
    


}
