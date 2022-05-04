using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [Header("Atual Projectile")]
    [SerializeField] Transform fireProjectiles_GRUP;
    [SerializeField] Transform corruptionProjectiles_GRUP;
    [SerializeField] Transform galaxyProjectiles_GRUP;
    [SerializeField] Transform carmesimProjectiles_GRUP;

    Transform projectileGrupSelected;

    ComboMaker comboMaker;


    private void Awake()
    {
        comboMaker = GameObject.Find("Player").GetComponent<ComboMaker>();
    }
    private void Start()
    {
        for (int i = 0; i < fireProjectiles_GRUP.childCount; i++)
        {
            fireProjectiles_GRUP.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < corruptionProjectiles_GRUP.childCount; i++)
        {
            corruptionProjectiles_GRUP.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < galaxyProjectiles_GRUP.childCount; i++)
        {
            galaxyProjectiles_GRUP.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < carmesimProjectiles_GRUP.childCount; i++)
        {
            carmesimProjectiles_GRUP.GetChild(i).gameObject.SetActive(false);
        }
    }


    public ProjectileController GetNextProjectileToShoot()
    {
        switch (comboMaker.GetProjectile())
        {
            case ProjectileType.FireStandard:
                projectileGrupSelected = fireProjectiles_GRUP;
                break;

            case ProjectileType.CorruptionStandard:
                projectileGrupSelected = corruptionProjectiles_GRUP;
                break;

            case ProjectileType.GalaxyStandard:
                projectileGrupSelected = galaxyProjectiles_GRUP;
                break;

            case ProjectileType.CarmesimStandard:
                projectileGrupSelected = carmesimProjectiles_GRUP;
                break;

            default:
                projectileGrupSelected = null;
                break;
        }

        ProjectileController projectileToReturn = projectileGrupSelected.GetChild(0).GetComponent<ProjectileController>();
        projectileToReturn.transform.SetAsLastSibling();

        return projectileToReturn;
    }









}
