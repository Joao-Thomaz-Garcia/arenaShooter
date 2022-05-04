using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileCollisionScript : MonoBehaviour
{
    [SerializeField] protected bool b_canHitWeakPoint;

    protected SphereCollider sphereColl;
    protected ProjectileController projectileController;

    [SerializeField] protected GameObject hitVFX_prefab;


    #region AWAKE, START, UPDATES
    protected virtual void Awake()
    {
        sphereColl = GetComponent<SphereCollider>();
        projectileController = GetComponent<ProjectileController>();
    }
    protected virtual void Start()
    {

    }
    #endregion



    #region ABSTRACT FUNCTIONS
    protected abstract void DoProjectileDamage(/* Pede o script onde o inimigo recebe dano */);
    #endregion

    public bool GetCanHitWeakPoint()
    {
        return b_canHitWeakPoint;
    }
}
