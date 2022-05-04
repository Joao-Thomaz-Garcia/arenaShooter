using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Dispersed : ExplosionScript
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
    #endregion



    protected override void DoExplosionDamage()
    {
        /// DA O DANO DA EXPLOSÃO NA AREA DE EFEITO.
        /// CRIA VARIAS OUTRAS BOMBINHAS QUE EXPLODEM TAMBEM.
    }

    protected override void SetExplosionParticle(GameObject _particlePrefab)
    {
        /// A PARTICULA É SETADA PELO PROJETIL, JUNTAMENTE COM O DoExplosionDamage()
        /// SE NEM UMA PARTICULA FOR SETADA, A PARTICULA STANDARD APARECE. /// TALVEZ POSSA SER UMA PARTICULA ROSA DE DEBUG. PARA DEMONSTRAR QUE HOUVE UM BUG.
    }
}
