using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBattle
{

    public enum TurnStatus 
    {
        NONE,
        PLAYER,
        ENEMY,
    }

    public interface ITurn
    {
        void OnStart();
    }


    public abstract class Turn : ITurn
    {
        TurnStatus status;

        public abstract void OnStart();
        public abstract void OnEnd();
    }

    public class PlayerTurn : Turn
    {
        public override void OnStart()
        {
            Debug.Log("Player Turn Start!");
        }
        public override void OnEnd()
        {
            Debug.Log("Player Turn End!");
        }

    }
    public class EnemyTurn : Turn
    {
        public override void OnStart()
        {
            Debug.Log("Enemy Turn Start!");
        }

        public override void OnEnd()
        {
            Debug.Log("Enemy Turn End!");
        }
    }


    public class TurnBattleSystem : MonoBehaviour
    {
        public static TurnBattleSystem Instance;
        Turn currentTurn;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            currentTurn = new PlayerTurn();
            currentTurn.OnStart();
        }

        public void SetTurn(Turn turn)
        {
            currentTurn.OnEnd();
            currentTurn = turn;
            currentTurn.OnStart();
        }

    }

}

