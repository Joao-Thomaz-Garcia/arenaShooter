using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager_Projec : MonoBehaviour
{
    [SerializeField] float baseDamage;
    float finalDamage;

    ProjectileType projectileType = ProjectileType.Nulo;

    ProjectileController projectileController;
    G_ProjectileModifiers projectileModifiers;

    private void Awake()
    {
        projectileController = GetComponent<ProjectileController>();
        projectileModifiers = Globals.Instance.projectileModifiers;

        projectileType = projectileController.GetProjectileType();
    }


    #region Calculate Final Damage
    void CalculateFinalDamage()
    {
        finalDamage = 0;
        finalDamage += baseDamage;

        if (projectileType == ProjectileType.FireStandard || projectileType == ProjectileType.FireRock || projectileType == ProjectileType.FireExplosion)
        {
            finalDamage += Calculate_FireDamageModifiers();
        }
        else if (projectileType == ProjectileType.CorruptionStandard || projectileType == ProjectileType.CorruptionArrow || projectileType == ProjectileType.CorruptionSphere)
        {
            finalDamage += Calculate_CorruptionDamageModifiers();
        }
        else if (projectileType == ProjectileType.GalaxyStandard || projectileType == ProjectileType.GalaxyGuiada || projectileType == ProjectileType.GalaxyArrow)
        {
            finalDamage += Calculate_GalaxyDamageModifiers();
        }
        else if (projectileType == ProjectileType.CarmesimStandard || projectileType == ProjectileType.CarmesimExplosion || projectileType == ProjectileType.CarmesimArrow)
        {
            finalDamage += Calculate_CaresimDamageModifiers();
        }
    }
    float Calculate_FireDamageModifiers()
    {
        float _valueToReturn = 0;
        _valueToReturn = projectileModifiers.GetFireModifiers().GetDamage();

        if (projectileType == ProjectileType.FireStandard)
        {

        }
        if (projectileType == ProjectileType.FireRock)
        {

        }
        if (projectileType == ProjectileType.FireExplosion)
        {

        }

        return _valueToReturn;
    }
    float Calculate_CorruptionDamageModifiers()
    {
        float _valueToReturn = 0;
        _valueToReturn = projectileModifiers.GetCorruptionModifiers().GetDamage();

        if (projectileType == ProjectileType.CorruptionStandard)
        {

        }
        else if (projectileType == ProjectileType.CorruptionArrow)
        {

        }
        else if (projectileType == ProjectileType.CorruptionSphere)
        {

        }

        return _valueToReturn;
    }
    float Calculate_GalaxyDamageModifiers()
    {
        float _valueToReturn = 0;
        _valueToReturn = projectileModifiers.GetGalaxyModifiers().GetDamage();

        if (projectileType == ProjectileType.GalaxyStandard)
        {

        }
        else if (projectileType == ProjectileType.GalaxyGuiada)
        {

        }
        else if (projectileType == ProjectileType.GalaxyArrow)
        {

        }

        return _valueToReturn;
    }
    float Calculate_CaresimDamageModifiers()
    {
        float _valueToReturn = 0;
        _valueToReturn = projectileModifiers.GetCarmesimModifiers().GetDamage();

        if (projectileType == ProjectileType.CarmesimStandard)
        {

        }
        else if (projectileType == ProjectileType.CarmesimExplosion)
        {

        }
        else if (projectileType == ProjectileType.CarmesimArrow)
        {

        }

        return _valueToReturn;
    }
    #endregion


    public float GetFinalDamage()
    {
        CalculateFinalDamage();
        return finalDamage;
    }

}
