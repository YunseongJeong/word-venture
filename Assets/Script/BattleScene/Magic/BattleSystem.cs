using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Deck_Manage;
using UnityEngine;
using MagicAffinity;

public class BattleSystem
{
    [SerializeField] static MagicAffinityTable magicAffinityTable = AssetDatabase.LoadAssetAtPath<MagicAffinityTable>("Assets/ScriptableObject/Magic Affinity Table.asset");

    static public int CalculateDamage(int damage, MagicType magicType, MagicType spellType, MagicType targetMagicType)
    {
        float result = damage;
        if (spellType == MagicType.Drop)
        {
            result *= 0.8f;
        }
        else if (spellType == MagicType.Summon)
        {
            result *= 0.67f;
        }

        result *= magicAffinityTable.GetAffinity(magicType, targetMagicType);

        return ((int)result);
    }
}
