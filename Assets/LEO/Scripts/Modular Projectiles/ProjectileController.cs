using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] ProjectileType projectileType;
    [SerializeField] protected float lifeTime;
    protected float time;
    protected bool b_canMove;

    Rigidbody rb;
    Damager_Projec damager;
    AmmoController ammoController;
    Transform player;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damager = GetComponent<Damager_Projec>();
        ammoController = GameObject.Find("Ammo").GetComponent<AmmoController>();
        player = GameObject.Find("Player").transform;
    }
    private void Start()
    {
        rb.freezeRotation = true;
    }

    public void Shoot()
    {
        StartMoveProjectile();
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= lifeTime)
        {
            DeactivateProjectile();
        }
    }


    public float GetTime()
    {
        return time;
    }


    public void ActivateProjectile()
    {
        StartMoveProjectile();
    }
    public void DeactivateProjectile()
    {
        gameObject.SetActive(false);
        time = 0;
        b_canMove = false;
    }
    public void StartMoveProjectile()
    {
        transform.position = player.transform.Find("Camera").Find("GUN").Find("FireSpot").position;
        transform.rotation = player.transform.Find("Camera").Find("GUN").Find("FireSpot").rotation;

        gameObject.SetActive(true);
        b_canMove = true;
        GetComponent<ParticleSystem>().Play();
    }





    public bool GetCanProjectileMove()
    {
        return b_canMove;
    }
    public ProjectileType GetProjectileType()
    {
        return projectileType;
    }
    public Damager_Projec GetProjecDamager()
    {
        return damager;
    }
}
