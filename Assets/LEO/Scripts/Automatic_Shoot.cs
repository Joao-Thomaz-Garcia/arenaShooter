using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic_Shoot : MonoBehaviour
{
    [SerializeField] float fireStandardFireRate;
    [SerializeField] float fireExplosionFireRate;
    [SerializeField] float fireRockFireRate;

    [SerializeField] float corruptionFireRate;
    [SerializeField] float galaxyFireRate;
    [SerializeField] float carmesimFireRate;

    ProjectileType atualProjectile = ProjectileType.Nulo;

    float timer;
    Transform gun;

    ComboMaker comboMaker;
    AmmoController ammoController;


    private void Awake()
    {
        comboMaker = GetComponent<ComboMaker>();
        ammoController = GameObject.Find("Ammo").GetComponent<AmmoController>();
    }


    private void FixedUpdate()
    {
        atualProjectile = comboMaker.GetProjectile();
        timer += Time.deltaTime;

        if (atualProjectile == ProjectileType.FireStandard)
        {
            FireStandardTimer();
        }
        else if (atualProjectile == ProjectileType.CorruptionStandard)
        {
            CorruptionStandardTimer();
        }
        else if (atualProjectile == ProjectileType.GalaxyStandard)
        {
            GalaxyStandardTimer();
        }
        else if (atualProjectile == ProjectileType.CarmesimStandard)
        {
            CarmesimStandardTimer();
        }
    }

    #region Projectiles Timers
    #region Fire
    void FireStandardTimer()
    {
        if (timer >= fireStandardFireRate - Globals.Instance.projectileModifiers.GetFireModifiers().GetFireRate())
        {
            // Shoot;
            ProjectileController _projectile = ammoController.GetNextProjectileToShoot();
            _projectile.ActivatePlayerProjectile();

            timer = 0;
        }
    }
    void FireArrowTimer()
    {

    }
    void FireRockTimer()
    {

    }
    #endregion

    void CorruptionStandardTimer()
    {
        if (timer >= corruptionFireRate - Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetFireRate())
        {
            // Shoot;
            ProjectileController _projectile = ammoController.GetNextProjectileToShoot();
            _projectile.ActivatePlayerProjectile();

            timer = 0;
        }
    }
    void GalaxyStandardTimer()
    {
        if (timer >= galaxyFireRate - Globals.Instance.projectileModifiers.GetGalaxyModifiers().GetFireRate())
        {
            // Shoot;
            ProjectileController _projectile = ammoController.GetNextProjectileToShoot();
            _projectile.ActivatePlayerProjectile();

            timer = 0;
        }
    }
    void CarmesimStandardTimer()
    {
        if (timer >= carmesimFireRate - Globals.Instance.projectileModifiers.GetCarmesimModifiers().GetFireRate())
        {
            // Shoot;
            ProjectileController _projectile = ammoController.GetNextProjectileToShoot();
            _projectile.ActivatePlayerProjectile();

            timer = 0;
        }
    }
    #endregion

    public ProjectileType GetProjectileSelected()
    {
        return atualProjectile;
    }

}
