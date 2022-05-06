using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Standard_Projec : ProjectileCollisionScript
{

    #region AWAKE, START, UPDATES
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        sphereColl.isTrigger = false; // Colisão normal
    }
    #endregion


    #region ABSTRACT FUNCTIONS
    protected override void DoProjectileDamage(/* Pede o script onde o inimigo recebe dano */)
    {

    }
    #endregion


    #region ON EVENTS
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == gameObject)
            return;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point + contact.normal;

        GameObject _hitVFXGO = Instantiate(hitVFX_prefab, pos, rot);

        var hitPsParts = _hitVFXGO.transform.GetChild(0).GetComponent<ParticleSystem>();
        Destroy(_hitVFXGO, hitPsParts.main.duration);

        if (collision.transform.GetComponent<DamageTaker>())
        {
            DamageTaker damageTaker = collision.transform.GetComponent<DamageTaker>();

            #region Se for o Carmesim Arrow
            if (projectileController.GetProjectileType() == ProjectileType.CarmesimArrow)
            {
                damageTaker.AddWeaknessHit();
            }
            #endregion


            float _damage = projectileController.GetProjecDamager().GetFinalDamage();
            damageTaker.TakeDamage(_damage, pos, projectileController);


            #region Se for o Galaxy Arrow
            if (GetComponent<Mover_Jumper_Projec>())
            {
                Mover_Jumper_Projec _moverJumper = GetComponent<Mover_Jumper_Projec>();
                _moverJumper.AddProjecJump();

                if(_moverJumper.gameObject.activeSelf)
                    StartCoroutine(_moverJumper.FindNewTarget());
            }
            else
            {
                projectileController.DeactivateProjectile();
            }
            #endregion
        }
        else
        {
            projectileController.DeactivateProjectile(); 
        }
    }
    #endregion


    #region Gets and Sets

    #endregion
}
