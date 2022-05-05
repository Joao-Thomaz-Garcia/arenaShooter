using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedSphereHitVFXScript : MonoBehaviour
{





    // SERVE PARA COLOCAR A PARTICULA NO LUGAR ONDE O HIT ACONTECEU.
    // PEGANDO O TRANSFORM.POSTION, QUANDO O PROJETIL HITA UMA PAREDE, ELE PEGA O TRANSFORM DA PAREDE, OU SEJA ONDE O PIVOT ESTA, E NÃO ONDE O HIT ACONTECEU.
    public void SetParticlePosition(Vector3 _pos)
    {
        transform.position = _pos;
        Vector3 _adicionalScale = new Vector3(Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetSphereRadious() + 1.5f, Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetSphereRadious() + 1.5f, Globals.Instance.projectileModifiers.GetCorruptionModifiers().GetSphereRadious() + 1.5f);
        transform.localScale = _adicionalScale;
    }



}
