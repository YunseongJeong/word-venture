using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBattle;

public class GameManager : MonoBehaviour
{
    private TurnBattleSystem battleSystem;

    void Start()
    {
        battleSystem = FindObjectOfType<TurnBattleSystem>();

        if (battleSystem == null)
        {
            Debug.LogError("TurnBattleSystem not found in the scene.");
        }
        else
        {
            Debug.Log("Battle Start!");
        }
    }
}