using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Round Setting", menuName = "New RoundSetup", order = 1)]
public class RoundSetup : ScriptableObject
{

    public List<EnemyTypes> EnemyType = new List<EnemyTypes>();
    public List<int> EnemyAmount = new List<int>();

}
