using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject GroundShooterEnemy;

    [SerializeField]
    GameObject playerObject;
    [SerializeField]
    GameObject projectilePrefab;

    public GameObject GetPlayerObject()
    {
        return playerObject;
    }
    public GameObject GetProjectilePrefab()
    {
        return projectilePrefab;
    }
}
