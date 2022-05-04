using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileMoverScript : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float bulletDropSpeed;

    protected Rigidbody rb;
    protected ProjectileController projectileController;

    protected Transform player;



    #region AWAKE, START, UPDATES
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        projectileController = GetComponent<ProjectileController>();
        player = GameObject.Find("Player").transform;
    }
    protected virtual void Start()
    {
        if (bulletDropSpeed > 0)
        {
            rb.mass = bulletDropSpeed;
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }
    }
    #endregion


    #region ABSTRACT FUNCTIONS
    protected abstract void MoveProjectile();
    #endregion

}
