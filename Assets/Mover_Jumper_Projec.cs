using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Jumper_Projec : ProjectileMoverScript
{
    [SerializeField] float jumpRadius;
    DamageTaker target;

    [SerializeField] int startJumps = 2;
    int atualNumberOfJumps;


    #region AWAKE, START, UPDATES
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        //atualNumberOfJumps = (int) Globals.Instance.projectileModifiers.GetGalaxyModifiers().GetJumps() + startJumps;
    }
    void FixedUpdate()
    {
        MoveProjectile();
    }
    #endregion
    
    public IEnumerator FindNewTarget()
    {
        yield return new WaitForEndOfFrame();
        Collider[] _colls = Physics.OverlapSphere(transform.position, jumpRadius);

        DamageTaker nearestDamageTaker = null;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < _colls.Length; i++)
        {
            if (target) 
            { 
                if (_colls[i].gameObject != target.gameObject) 
                {
                    if (_colls[i].GetComponent<DamageTaker>())
                    {
                        DamageTaker _damageTaker = _colls[i].GetComponent<DamageTaker>();

                        float _damageTakerDistance = Vector3.Distance(transform.position, _damageTaker.transform.position);
                        if (_damageTakerDistance <= closestDistance && !_damageTaker.GetCanNotBeChasedByJumperProjec()) // SE O CanNotBeChased, FOR FALSO ELE SEGUE. OU SEJA SE ELE N�O PODE SER SEGUIDO FOR FALSO, ELE PODE SEGUIR.
                        {
                            nearestDamageTaker = _damageTaker;
                            closestDistance = _damageTakerDistance;
                        }
                    }
                } 
            }
            else
            {
                if (_colls[i].GetComponent<DamageTaker>())
                {
                    DamageTaker _damageTaker = _colls[i].GetComponent<DamageTaker>();

                    float _damageTakerDistance = Vector3.Distance(transform.position, _damageTaker.transform.position);
                    if (_damageTakerDistance <= closestDistance && !_damageTaker.GetCanNotBeChasedByJumperProjec()) // SE O CanNotBeChased, FOR FALSO ELE SEGUE. OU SEJA SE ELE N�O PODE SER SEGUIDO FOR FALSO, ELE PODE SEGUIR.
                    {
                        nearestDamageTaker = _damageTaker;
                        closestDistance = _damageTakerDistance;
                    }
                }
            }
        }

        target = nearestDamageTaker;
    }


    #region ABSTRACT FUNCTIONS
    protected override void MoveProjectile()
    {
        if (!projectileController.GetCanProjectileMove())
            return;

        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.5f)
            {
                StartCoroutine(FindNewTarget());
            }
        }
        else
        {
            rb.velocity = transform.forward * (speed + Globals.Instance.projectileModifiers.GetFireModifiers().GetMoveSpeed());
        }

        
    }
    #endregion

    public DamageTaker GetProjectTarget()
    {
        return target;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, jumpRadius);
    }


    public void AddProjecJump()
    {
        atualNumberOfJumps++;
        if (atualNumberOfJumps >= Globals.Instance.projectileModifiers.GetGalaxyModifiers().GetJumps() + startJumps)
        {
            projectileController.DeactivateProjectile();
        }
    }
}
