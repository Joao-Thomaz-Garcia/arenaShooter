using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float CircleRadius = 4.5f;


    int RoundCounter = 0;
    [SerializeField]
    List<RoundSetup> Rounds = new List<RoundSetup>();


    List<GameObject> spawnedEnemys = new List<GameObject>();
    //List<float> spawnedEnemysHealth = new List<float>();


    private void Start()
    {
        SpawnNewRound(Rounds[RoundCounter]);


    }

    private void Update()
    {
        CheckAndClear();
    }

    private void FixedUpdate()
    {
        if (spawnedEnemys.Count == 0 && RoundCounter != Rounds.Count)
        {
            SpawnNewRound(Rounds[RoundCounter]);
            //Spawnar upgrade
        }
        else if (spawnedEnemys.Count == 0 && RoundCounter >= Rounds.Count)
            Destroy(GetComponent<EnemyManager>().GetPlayerObject());
    }

    void SpawnNewRound(RoundSetup Round)
    {
        var enemyManager = GetComponent<EnemyManager>();
        var roundData = Round.roundData;
        for (int i = 0; i < Round.roundData.Count; i++)
        {
            for (int j = 0; j < roundData[i].GetEnemyAmount(); j++)
            {
                int enemyKind = (int)roundData[i].GetEnemyType();
                var enemyInList = enemyManager.EnemysList[enemyKind];

                Vector3 SpawnPoint = Random.insideUnitSphere * CircleRadius;
                SpawnPoint += transform.position;

                //Ajustar a altura de acordo com o tipo de inimigo.
                SpawnPoint.y = 0.75f;


                var playerObject = enemyManager.GetPlayerObject();


                GameObject go = Instantiate(enemyInList, SpawnPoint, Quaternion.identity);
                spawnedEnemys.Add(go);

                var manageEnemyClass = go.GetComponent<EnemyClass>();
                var enemyHealth = manageEnemyClass.GetHealth();

                //spawnedEnemysHealth.Add(enemyHealth);

                manageEnemyClass.SetPlayerObject(playerObject);


            }

        }

        RoundCounter++;
    }

    void CheckAndClear()
    {
        foreach(GameObject go in spawnedEnemys)
        {
            if (go == null)
                spawnedEnemys.Remove(go);
            
        }
    }

    /*
    private void SpawnTimer()
    {
        if(spawnedEnemys.Count == 0)
        {
            SpawnEnemys(amountOfEnemys);

        }

    }*/
    //Setar por Scriptable Object.
    //Decidir qual inimigo spawnar pelo Scriptable Object também.

    /*
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


    }*/
    


}
