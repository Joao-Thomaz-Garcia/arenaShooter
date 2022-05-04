using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Guided_Projec : ProjectileMoverScript
{
    [SerializeField] bool b_stopsBeforeMove;

    // O projetil começa lento e vai ganhando velocidade a os poucos.
    [SerializeField] AnimationCurve animCurve;
    [SerializeField] Transform target;

    Vector3 restPlace;


    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();

        // O PROJETIL PODERIA FICAR ATRELADO AO JOGADOR ENQUANTO ELE NÃO COMEÇA IR EM DIREÇÃO AO TARGET, PARA QUE ASSIM CASO O JOGADOR SE MOVA, O PROJETIL SIGA SEU TRANSFORM. QUANDO ESTIVER INDO PARA O TARGET REMOVEMOS O PARENT DO PROJETIL COM ELE PODENDO ANDAR LIVREMENTE.
        if (b_stopsBeforeMove)
            restPlace = new Vector3(Random.Range(transform.localPosition.x - 1, transform.localPosition.x + 1), Random.Range(transform.localPosition.y, transform.localPosition.y + 1), Random.Range(transform.localPosition.z, transform.localPosition.z));
        else
            restPlace = new Vector3(Random.Range(transform.localPosition.x - 1, transform.localPosition.x + 1), Random.Range(transform.localPosition.y, transform.localPosition.y + 1), Random.Range(transform.localPosition.z, transform.localPosition.z + 1));
    }
    private void FixedUpdate()
    {
        MoveProjectile();
    }


    protected override void MoveProjectile()
    {
        if (!projectileController.GetCanProjectileMove())
            return;

        float _time = projectileController.GetTime();

        if (b_stopsBeforeMove)
        {
            if (speed != 0)
            {

                speed = animCurve.Evaluate(_time);

                if (_time < 1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, restPlace, speed);
                }
                else if(_time > 2)
                {
                    if (target == null)
                    {
                        /// FindTarget(); <-----

                        // SE MESMO DEPOIS DO FIND, AINDA NÃO TIVER ENCONTRADO TARGET, ELE SE AUTO DESTROI.
                        if (target == null)
                        {
                            projectileController.DeactivateProjectile();
                            return;
                        }
                    }

                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
                }
            }
        }
        else
        {
            if (speed != 0)
            {
                speed = animCurve.Evaluate(_time);

                if (_time < 1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, restPlace, speed);
                }
                else
                {
                    if (target == null)
                    {
                        /// FindTarget(); <-----

                        // SE MESMO DEPOIS DO FIND, AINDA NÃO TIVER ENCONTRADO TARGET, ELE SE AUTO DESTROI.
                        if (target == null)
                        {
                            projectileController.DeactivateProjectile();
                            return;
                        }
                    }

                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
                }
            }
        }

    }
}
