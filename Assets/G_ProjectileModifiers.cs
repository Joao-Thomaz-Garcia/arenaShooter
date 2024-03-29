using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_ProjectileModifiers : MonoBehaviour
{
    [Space(20)] [SerializeField] FireProjectilesModifiers fireModifiers = new FireProjectilesModifiers();
    [Space(20)] [SerializeField] CorruptionProjectilesModifiers corruptionModifiers = new CorruptionProjectilesModifiers();
    [Space(20)] [SerializeField] GalaxyProjectilesModifiers galaxyModifiers = new GalaxyProjectilesModifiers();
    [Space(20)] [SerializeField] CarmesimProjectilesModifiers carmesimModifiers = new CarmesimProjectilesModifiers();


    public float GetWeakPointDamageByProjecType(ProjectileType _projecType)
    {
        float valueToReturn = 0;
        switch (_projecType)
        {
            case ProjectileType.CorruptionArrow:
                valueToReturn = corruptionModifiers.GetWeakPointDamage();
                break;
            case ProjectileType.CarmesimArrow:
                valueToReturn = carmesimModifiers.GetCarmesimArrowFixedWeakPointDamage();
                break;
        }

        return valueToReturn;
    }

    public void AddDamageUpgrades(ProjectileType _projecType, float _damage)
    {
        if (_projecType == ProjectileType.FireStandard || _projecType == ProjectileType.FireExplosion || _projecType == ProjectileType.FireRock)
        {
            GetFireModifiers().AddDamage(_damage);
        }
        else if (_projecType == ProjectileType.CorruptionStandard || _projecType == ProjectileType.CorruptionSphere || _projecType == ProjectileType.CorruptionArrow)
        {
            GetCorruptionModifiers().AddDamage(_damage);
        }
        else if (_projecType == ProjectileType.GalaxyStandard || _projecType == ProjectileType.GalaxyArrow || _projecType == ProjectileType.GalaxyGuiada)
        {
            GetGalaxyModifiers().AddDamage(_damage);
        }
        else if (_projecType == ProjectileType.CarmesimStandard || _projecType == ProjectileType.CarmesimArrow || _projecType == ProjectileType.CarmesimExplosion)
        {
            GetCarmesimModifiers().AddDamage(_damage);
        }
    }
    public void AddMoveSpeedUpgrades(ProjectileType _projecType, float _moveSpeed)
    {
        if (_projecType == ProjectileType.FireStandard || _projecType == ProjectileType.FireExplosion || _projecType == ProjectileType.FireRock)
        {
            GetFireModifiers().AddMoveSpeed(_moveSpeed);
        }
        else if (_projecType == ProjectileType.CorruptionStandard || _projecType == ProjectileType.CorruptionSphere || _projecType == ProjectileType.CorruptionArrow)
        {
            GetCorruptionModifiers().AddMoveSpeed(_moveSpeed);
        }
        else if (_projecType == ProjectileType.GalaxyStandard || _projecType == ProjectileType.GalaxyArrow || _projecType == ProjectileType.GalaxyGuiada)
        {
            GetGalaxyModifiers().AddMoveSpeed(_moveSpeed);
        }
        else if (_projecType == ProjectileType.CarmesimStandard || _projecType == ProjectileType.CarmesimArrow || _projecType == ProjectileType.CarmesimExplosion)
        {
            GetCarmesimModifiers().AddMoveSpeed(_moveSpeed);
        }
    }
    public void AddFireRateUpgrades(ProjectileType _projecType, float _fireRate)
    {
        if (_projecType == ProjectileType.FireStandard || _projecType == ProjectileType.FireExplosion || _projecType == ProjectileType.FireRock)
        {
            GetFireModifiers().AddFireRate(_fireRate);
        }
        else if (_projecType == ProjectileType.CorruptionStandard || _projecType == ProjectileType.CorruptionSphere || _projecType == ProjectileType.CorruptionArrow)
        {
            GetCorruptionModifiers().AddFireRate(_fireRate);
        }
        else if (_projecType == ProjectileType.GalaxyStandard || _projecType == ProjectileType.GalaxyArrow || _projecType == ProjectileType.GalaxyGuiada)
        {
            GetGalaxyModifiers().AddFireRate(_fireRate);
        }
        else if (_projecType == ProjectileType.CarmesimStandard || _projecType == ProjectileType.CarmesimArrow || _projecType == ProjectileType.CarmesimExplosion)
        {
            GetCarmesimModifiers().AddFireRate(_fireRate);
        }
    }

    public FireProjectilesModifiers GetFireModifiers()
    {
        return fireModifiers;
    }
    public CorruptionProjectilesModifiers GetCorruptionModifiers()
    {
        return corruptionModifiers;
    }
    public GalaxyProjectilesModifiers GetGalaxyModifiers()
    {
        return galaxyModifiers;
    }
    public CarmesimProjectilesModifiers GetCarmesimModifiers()
    {
        return carmesimModifiers;
    }

}


[System.Serializable]
public class FireProjectilesModifiers
{
    [SerializeField] float adicionalDamage;
    [SerializeField] float adicionalMoveSpeed;
    [SerializeField] float adicionalFireRate;

    [Header("Individual 1")]
    [SerializeField] float adicionalExplosionDamage;
    [Header("Individual 2")]
    [SerializeField] float adicionalSmallProjec;


    #region Add
    public void AddDamage(float _damage) { adicionalDamage += _damage; }
    public void AddMoveSpeed(float _moveSpeed) { adicionalMoveSpeed += _moveSpeed; }
    public void AddFireRate(float _fireRate) { adicionalFireRate += _fireRate; }

    public void AddExplosionDamage(float _damage) { adicionalExplosionDamage += _damage; }

    public void AddNewSmallProjectiles(float _newSmallProjec) { adicionalSmallProjec += _newSmallProjec; }
    #endregion


    #region Gets
    public float GetDamage() { return adicionalDamage; }
    public float GetMoveSpeed() { return adicionalMoveSpeed; }
    public float GetFireRate() { return adicionalFireRate; }

    public float GetExplosionDamage() { return adicionalExplosionDamage; }
    public float GetSmallProjectilesCount() { return adicionalSmallProjec; }
    #endregion
}


[System.Serializable]
public class CorruptionProjectilesModifiers
{
    [SerializeField] float adicionalDamage;
    [SerializeField] float adicionalMoveSpeed;
    [SerializeField] float adicionalFireRate;

    [Header("Individual 1")]
    [SerializeField] float adicionalWeakPointDamage; // Arrow
    [Header("Individual 2")]
    [SerializeField] float adicionalSphereRadious;

    #region Add
    public void AddDamage(float _damage) { adicionalDamage += _damage; }
    public void AddMoveSpeed(float _moveSpeed) { adicionalMoveSpeed += _moveSpeed; }
    public void AddFireRate(float _fireRate) { adicionalFireRate += _fireRate; }

    public void AddWeakPointDamage(float _weakPointDamage) { adicionalWeakPointDamage += _weakPointDamage; }
    public void AddSphereRadious(float _radious) { adicionalSphereRadious += _radious; }
    #endregion


    #region Gets
    public float GetDamage() { return adicionalDamage; }
    public float GetMoveSpeed() { return adicionalMoveSpeed; }
    public float GetFireRate() { return adicionalFireRate; }

    public float GetWeakPointDamage() { return adicionalWeakPointDamage; }
    public float GetSphereRadious() { return adicionalSphereRadious; }
    #endregion
}


[System.Serializable]
public class GalaxyProjectilesModifiers
{
    [SerializeField] float adicionalDamage;
    [SerializeField] float adicionalMoveSpeed;
    [SerializeField] float adicionalFireRate;

    [Header("Individual 1")]
    [SerializeField] float adicionalDistance; // Aumenta o tempo de vida
    [Header("Individual 2")]
    [SerializeField] float adicionalJumps;


    #region Add
    public void AddDamage(float _damage) { adicionalDamage += _damage; }
    public void AddMoveSpeed(float _moveSpeed) { adicionalMoveSpeed += _moveSpeed; }
    public void AddFireRate(float _fireRate) { adicionalFireRate += _fireRate; }

    public void AddDistance(float _distance) { adicionalDistance += _distance; }
    public void AddJumps(float _jumpQuantity) { adicionalJumps += _jumpQuantity; }
    #endregion

    #region Gets
    public float GetDamage() { return adicionalDamage; }
    public float GetMoveSpeed() { return adicionalMoveSpeed; }
    public float GetFireRate() { return adicionalFireRate; }

    public float GetDistance() { return adicionalDistance; }
    public float GetJumps() { return adicionalJumps; }
    #endregion
}


[System.Serializable]
public class CarmesimProjectilesModifiers
{
    [SerializeField] float adicionalDamage;
    [SerializeField] float adicionalMoveSpeed;
    [SerializeField] float adicionalFireRate;

    [Header("Individual 1")]
    [SerializeField] float adicionalWeakness;
    [Header("Individual 2")]
    [SerializeField] float adicionalOvertimeDamage;

    [Header("Fixed bonus CARMESIM ARROW")]
    [SerializeField] float carmesimArrowFixedWeakPointDamage;

    #region Add
    public void AddDamage(float _damage) { adicionalDamage += _damage; }
    public void AddMoveSpeed(float _moveSpeed) { adicionalMoveSpeed += _moveSpeed; }
    public void AddFireRate(float _fireRate) { adicionalFireRate += _fireRate; }

    public void AddWeakness(float _weakness) { adicionalWeakness += _weakness; }
    public void AddOvertimeDamage(float _damageOvertime) { adicionalOvertimeDamage += _damageOvertime; }
    #endregion

    #region Gets
    public float GetDamage() { return adicionalDamage; }
    public float GetMoveSpeed() { return adicionalMoveSpeed; }
    public float GetFireRate() { return adicionalFireRate; }

    public float GetWeakness() { return adicionalWeakness; }
    public float GetOvertimeDamage() { return adicionalOvertimeDamage; }
    #endregion

    public float GetCarmesimArrowFixedWeakPointDamage()
    {
        return carmesimArrowFixedWeakPointDamage;
    }
}
