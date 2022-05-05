using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] bool b_canBeChasedByJumperProjec;
    [SerializeField] bool b_isWeakPoint;
    [SerializeField] GameObject hitDamagePopUp;

    [SerializeField] float maxStackableWeaknessHits;
    int atualWeaknessHits = 0;

    public void TakeDamage(float _damage, Vector3 _hitPopUpPos, ProjectileController _projecController)
    {
        if (GetComponent<PlayerHealth>())
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            playerHealth.SetHealth(_damage);
            return;
        }

        /// SE UM DAMAGE TAKER FOR COLOCADO EM UM GAMEOJBECT FILHO DO ENEMY CLASS, ELE RECEBERA 2X O MESMO DANO. ENTÃO O CORRETO É SEPARAR ESSA FUNÇÃO ENTRE SE É OU NÃO UM WEAKPOINT, PQ SE FOR ELE NÃO ADICIONA NO _DAMAGE O DANO DO PROJETIL BASE, E SIM, APENAS O BONUS DE PONTO FRACO.
        if (_projecController)
        {
            if (b_isWeakPoint && _projecController.GetComponent<ProjectileCollisionScript>().GetCanHitWeakPoint())
            {
                _damage += atualWeaknessHits * Globals.Instance.projectileModifiers.GetWeakPointDamageByProjecType(_projecController.GetProjectileType()); // PARA CADA PONTO STACKADO DE FRAQUEZA, MULTIPLICA O DANO RECEBIDO DO INIMIGO POR QUANTO DE FRAQUEZA ADICIONAL.
            }
        }


        HitPopUpScript _hitDamageGO = Instantiate(hitDamagePopUp, _hitPopUpPos, Quaternion.identity).GetComponent<HitPopUpScript>();
        _hitDamageGO.SetDamageText(_damage);

        GetComponent<EnemyClass>().TakeDamage(_damage);

    }

    public void AddWeaknessHit()
    {
        if (atualWeaknessHits < maxStackableWeaknessHits)
        {
            atualWeaknessHits++;
        }
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
    public bool GetCanNotBeChasedByJumperProjec()
    {
        return b_canBeChasedByJumperProjec;
    }
}
