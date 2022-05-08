using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Continuous_Projec : ProjectileCollisionScript
{


    #region AWAKE, START, UPDATES
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        sphereColl.isTrigger = true; // Colisao por trigger
    }
    #endregion


    #region ABSTRACT FUNCTIONS
    protected override void DoProjectileDamage(/* Pede o script onde o inimigo recebe dano */)
    {

    }
    #endregion


    #region ON EVENTS
    private void OnTriggerEnter(Collider other)
    {
        GameObject _hitGO = Instantiate(hitVFX_prefab, other.transform.position, Quaternion.identity);

        var hitPsParts = _hitGO.transform.GetChild(0).GetComponent<ParticleSystem>();
        _hitGO.GetComponent<CorruptedSphereHitVFXScript>().SetParticlePosition(transform.position);
        Destroy(_hitGO, hitPsParts.main.duration);


        if (other.transform.GetComponent<DamageTaker>())
        {
            DamageTaker damageTaker = other.transform.GetComponent<DamageTaker>();

            float _damage = projectileController.GetProjecDamager().GetFinalDamage();
            damageTaker.TakeDamage(_damage, other.transform.position, projectileController, this.gameObject);
        }

        // OS PROJETEIS COMO ESTE SÓ PODEM SER DESTRUIDOS PELO TEMPO DE VIDA.
        //projectileController.DeactivateProjectile();
    }
    #endregion


    #region Gets and Sets
    
    #endregion
}
