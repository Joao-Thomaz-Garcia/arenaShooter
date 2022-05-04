using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_PrefabGetter : MonoBehaviour
{
    [Header("Standard Projectile")]
    [SerializeField] GameObject standardProjectile_Prefab;

    [Header("Fire Projectiles")]
    [SerializeField] GameObject fireStandard_Prefab;
    [SerializeField] GameObject fireExplosion_Prefab;
    [SerializeField] GameObject fireRock_Prefab;

    [Header("Corruption Projectiles")]
    [SerializeField] GameObject corruptionStandard_Prefab;
    [SerializeField] GameObject corruptionArrow_Prefab;
    [SerializeField] GameObject corruptionSphere_Prefab;

    [Header("Galaxy Projectiles")]
    [SerializeField] GameObject galaxyStandard_Prefab;
    [SerializeField] GameObject galaxyGuiada_Prefab;
    [SerializeField] GameObject galaxyArrow_Prefab;

    [Header("Carmesim Projectiles")]
    [SerializeField] GameObject carmesimStandard_Prefab;
    [SerializeField] GameObject carmesimArrow_Prefab;
    [SerializeField] GameObject carmesimExplosion_Prefab;




    public GameObject GetProjectilePrefab(ProjectileType _projectileType)
    {
        GameObject prefabToReturn = null;

        switch (_projectileType)
        {
            case ProjectileType.FireStandard:
                prefabToReturn = fireStandard_Prefab;
                break;

            case ProjectileType.FireExplosion:
                prefabToReturn = fireExplosion_Prefab;
                break;

            case ProjectileType.FireRock:
                prefabToReturn = fireRock_Prefab;
                break;

            case ProjectileType.CorruptionStandard:
                prefabToReturn = corruptionStandard_Prefab;
                break;

            case ProjectileType.CorruptionArrow:
                prefabToReturn = corruptionArrow_Prefab;
                break; 

            case ProjectileType.CorruptionSphere:
                prefabToReturn = corruptionSphere_Prefab;
                break;

            case ProjectileType.GalaxyStandard:
                prefabToReturn = galaxyStandard_Prefab;
                break;

            case ProjectileType.GalaxyGuiada:
                prefabToReturn = galaxyGuiada_Prefab;
                break;

            case ProjectileType.CarmesimStandard:
                prefabToReturn = carmesimStandard_Prefab;
                break;

            case ProjectileType.CarmesimArrow:
                prefabToReturn = carmesimArrow_Prefab;
                break;

            case ProjectileType.CarmesimExplosion:
                prefabToReturn = carmesimExplosion_Prefab;
                break;


            default:
                prefabToReturn = standardProjectile_Prefab;
                break;
        }

        return prefabToReturn;
    }

}
