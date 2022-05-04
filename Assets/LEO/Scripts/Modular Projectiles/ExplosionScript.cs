using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExplosionScript : MonoBehaviour
{
    [SerializeField] protected float explosionRadious;
    [SerializeField] protected float explosionDamage;


    #region AWAKE, START, UPDATES
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        DoExplosionDamage();
    }
    #endregion


    #region ABSTRACT FUNCTIONS
    protected abstract void DoExplosionDamage();
    protected abstract void SetExplosionParticle(GameObject _particlePrefab);
    #endregion


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadious);
    }

}
