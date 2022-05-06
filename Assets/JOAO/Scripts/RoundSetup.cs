using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Round Setting", menuName = "New RoundSetup", order = 1)]
public class RoundSetup : ScriptableObject
{
    public List<EnemyTypesAndAmounts> roundData = new List<EnemyTypesAndAmounts>();

}

[System.Serializable]
public class EnemyTypesAndAmounts
{
    [SerializeField]
    EnemyTypes enemyType;
    [SerializeField]
    int enemyAmount;

    public EnemyTypes GetEnemyType()
    {
        return enemyType;
    }
    public int GetEnemyAmount()
    {
        return enemyAmount;
    }
}
