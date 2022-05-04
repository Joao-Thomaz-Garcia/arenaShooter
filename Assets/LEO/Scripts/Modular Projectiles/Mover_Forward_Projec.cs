using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Forward_Projec : ProjectileMoverScript
{
    #region AWAKE, START, UPDATES
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }
    void FixedUpdate()
    {
        MoveProjectile();
    }
    #endregion


    #region ABSTRACT FUNCTIONS
    protected override void MoveProjectile()
    {
        if (!projectileController.GetCanProjectileMove())
            return;

        if (speed != 0)
        {
            rb.velocity = transform.forward * (speed + Globals.Instance.projectileModifiers.GetFireModifiers().GetMoveSpeed());
        }
    }
    #endregion
}
