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

    #region AWAKE, START, UPDATES
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damager = GetComponent<Damager_Projec>();
        ammoController = GameObject.Find("Ammo").GetComponent<AmmoController>();
        player = GameObject.Find("Player").transform;
    }
    private IEnumerator Start()
    {
        rb.freezeRotation = true;
        ProjecPopulateConfiguration();

        yield return new WaitForEndOfFrame(); // Para não dar erro do particle system não ter sido iniciado, e eu estar tentando modificar uma variavel.

        /*ParticleSystem.MainModule mainModule = GetComponent<ParticleSystem>().main;
        mainModule.duration = lifeTime;
        mainModule.startLifetime = lifeTime;*/
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= lifeTime)
        {
            DeactivateProjectile();
        }
    }
    #endregion

    // SERVE PARA MODIFICAR CERTOS COMPONENTES BASEADO NAS NECESSIDADES DE CADA PROJETIL
    void ProjecPopulateConfiguration()
    {
        switch (projectileType)
        {
            case ProjectileType.FireStandard:
                break;
            case ProjectileType.FireExplosion:
                break;
            case ProjectileType.FireRock:
                break;
            case ProjectileType.CorruptionStandard:
                break;
            case ProjectileType.CorruptionArrow:
                break;
            case ProjectileType.CorruptionSphere:
                Vector3 _adicionalScale = new Vector3(Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetSphereRadious() + 1, Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetSphereRadious() + 1, Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetSphereRadious() + 1); // ESSES +1 SÃO O 1 DA ESCALA INICIAL, PARA QUE ELA NÃO SEJA PERDIDA.
                transform.localScale = _adicionalScale;
                break;
            case ProjectileType.GalaxyStandard:
                break;
            case ProjectileType.GalaxyGuiada:
                break;
            case ProjectileType.GalaxyArrow:
                break;
            case ProjectileType.CarmesimStandard:
                break;
            case ProjectileType.CarmesimArrow:
                break;
            case ProjectileType.CarmesimExplosion:
                break;
        }
    }


    public void Shoot()
    {
        StartMoveProjectile();
    }




    public float GetTime()
    {
        return time;
    }


    public void ActivateProjectile()
    {
        ProjecPopulateConfiguration();
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
