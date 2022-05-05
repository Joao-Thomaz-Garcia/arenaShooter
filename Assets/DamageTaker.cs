using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] bool b_isWeakPoint;
    [SerializeField] GameObject hitDamagePopUp;

    public void TakeDamage(float _damage, Vector3 _hitPopUpPos, ProjectileController _projecController)
    {
        if (GetComponent<PlayerHealth>())
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            playerHealth.SetHealth(_damage);
            return;
        }

        if (_projecController)
        {
            if (b_isWeakPoint && _projecController.GetComponent<ProjectileCollisionScript>().GetCanHitWeakPoint())
            {
                _damage += Globals.Instance.projectileModifiers.GetWeakPointDamageByProjecType(_projecController.GetProjectileType());
            }
        }


        HitPopUpScript _hitDamageGO = Instantiate(hitDamagePopUp, _hitPopUpPos, Quaternion.identity).GetComponent<HitPopUpScript>();
        _hitDamageGO.SetDamageText(_damage);

        GetComponent<EnemyClass>().SetHealth(-_damage);
    }

    public void SetHitPopUp(GameObject hitPopUp)
    {
        this.hitDamagePopUp = hitPopUp;
    }
    public GameObject GetHitPopUp()
    {
        return hitDamagePopUp;
    }
    public bool GetIsWeakPoint()
    {
        return b_isWeakPoint;
    }
}
