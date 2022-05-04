using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTypes { }


public enum ProjectileType 
{ 
    Nulo,
    
    FireStandard, FireExplosion, FireRock,

    CorruptionStandard, CorruptionArrow, CorruptionSphere,

    GalaxyStandard, GalaxyGuiada, GalaxyArrow,

    CarmesimStandard, CarmesimArrow, CarmesimExplosion
}

public enum InteractableObjectsType { Nulo, UpgradeMachine }

public enum EnemyStatesType { Innactive, Chase, Dashing, Attack }
