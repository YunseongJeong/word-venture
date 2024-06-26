using System.Collections;
using System.Collections.Generic;
using TurnBattle;
using UnityEngine;

namespace TurnBattle
{
    public class TurnBattleDebugButton : MonoBehaviour
    {
        public void EndPlayerTurn()
        {
            TurnBattleSystem.Instance.ChangeTurn(TurnBattleSystem.EnemyTurn);
        }

        public void EndEnemyTurn()
        {
            TurnBattleSystem.Instance.ChangeTurn(TurnBattleSystem.PlayerTurn);
        }
    }

}

