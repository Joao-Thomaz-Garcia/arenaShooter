using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMachineScript : MonoBehaviour
{
    [SerializeField] float timeToSpawnUpgrade;
    float timer = 0;

    [SerializeField] GameObject[] upgrades_prefabs;
    [SerializeField] Transform[] spawnPoint;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToSpawnUpgrade)
        {
            timer = 0;
            SpawnUpgrade();
        }
    }

    void SpawnUpgrade()
    {
        for (int i = 0; i < 3; i++)
        {
            int _RNG = Random.Range(0, upgrades_prefabs.Length);

            if (spawnPoint[i].childCount > 0)
            {
                Destroy(spawnPoint[i].GetChild(0).gameObject);
            }

            GameObject _go = Instantiate(upgrades_prefabs[_RNG], spawnPoint[i].position, Quaternion.identity);
            _go.transform.SetParent(spawnPoint[i]);
        }
    }
}
