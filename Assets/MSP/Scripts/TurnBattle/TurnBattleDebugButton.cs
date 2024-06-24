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
            TurnBattleSystem.Instance.SetTurn(new EnemyTurn());
        }

        public void EndEnemyTurn()
        {
            TurnBattleSystem.Instance.SetTurn(new PlayerTurn());
        }
    }

}

