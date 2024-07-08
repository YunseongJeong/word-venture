using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace Enemy
{

    public abstract class EnemyAction
    {
        protected Enemy enemy;
        protected EnemyAction(Enemy enemy)
        {
            this.enemy = enemy;
        }
        public abstract void PlayAction(float distanceToPlayer);

    }

    public class EnemyAttackAction : EnemyAction
    {

        public EnemyAttackAction(Enemy enemy) : base(enemy) { }

        public override void PlayAction(float distanceToPlayer)
        {
            enemy.Attack(distanceToPlayer);
        }
    }

    public class EnemyMoveAction : EnemyAction
    {

        public EnemyMoveAction(Enemy enemy) : base(enemy) { }
        public override void PlayAction(float distanceToPlayer)
        {

            float tempMoveDistance;

            if (distanceToPlayer > enemy.moveDistance + enemy.attackRange)
            {
                tempMoveDistance = enemy.moveDistance;
            }
            else
            {
                tempMoveDistance = distanceToPlayer - enemy.attackRange;
            }

            enemy.StartCoroutine(enemy.MoveDistance(tempMoveDistance));
        }
    }


    public enum ActionType
    {
        ATTACK = 0, MOVE = 1
    }


    public class Enemy : MonoBehaviour
    { 
        protected SlimeAnimator animator;

        protected TMP_Text hpText;

        public Deck_Manage.MagicType enemyType;

        [SerializeField] protected int id;
        protected int hp = 1;
        protected int maxHp = 1;
        protected int damage;

        public float moveDistance = 5;

        public float attackRange = 3;

        private Vector3 tempVector3 = new Vector3();
        float turnTime;

        [SerializeField] private List<EnemyAction> enemyActions = new List<EnemyAction>();
        
        public void InitEnemyData(EnemyData enemyData)
        {
            id = enemyData.id;
            maxHp = enemyData.maxHp;
            hp = maxHp;
            moveDistance = enemyData.moveDistance;
            attackRange = enemyData.attackRange;
            damage = enemyData.damage;
            enemyType = enemyData.type;
            UpdateIndicator();
        }

        private void InitEnemyActions()
        {
            enemyActions.Add(new EnemyAttackAction(this));
            enemyActions.Add(new EnemyMoveAction(this));
        }
        


        private ActionType MakeActionDecision(float distanceToPlayer)
        {

            if (distanceToPlayer > attackRange)
            {
                return ActionType.MOVE;
            } else
            {
                return ActionType.ATTACK;
            }
        }

        public void UpdateIndicator()
        {
            hpText.SetText(hp.ToString());
        }

        

        public void PlayTurnAction(float distanceToPlayer)
        {
            enemyActions[(int) MakeActionDecision(distanceToPlayer)].PlayAction(distanceToPlayer);
        }


        public IEnumerator MoveDistance(float distance)
        {
            animator.MoveStart();
            float moveSpeed = moveDistance / turnTime;
            float movedDistance = 0;
            while (movedDistance <= distance)
            {
                
                yield return new WaitForSeconds(0.01f);
                movedDistance += moveSpeed * 0.01f;
                Move(-1, moveSpeed * 0.01f);
            }
            StopMove();
        }

        private void Awake()
        {
            InitIndicators();
            InitEnemyActions();
        }

        protected virtual void Start()
        {
            animator = GetComponent<SlimeAnimator>();
            turnTime = TurnBattle.TurnBattleSystem.turnTime;
        }

   

        protected void FaceToDirection(int direction)
        {
            if (direction > 0)
            {
                direction = 1;
            } else if (direction < 0)
            {
                direction = -1;
            } else
            {
                return;
            }
            tempVector3 = transform.localScale;
            tempVector3.x = Mathf.Abs(tempVector3.x) * direction;
            transform.localScale = tempVector3;
        }

        public void Move(int direction, float moveStep) {
            FaceToDirection(direction);
            tempVector3 = transform.position;
            tempVector3.x = tempVector3.x + moveStep * direction;
            transform.position = tempVector3;
            
        }

        protected virtual void StopMove()
        {
            animator.MoveEnd();
        }

        virtual public void Attack(float distanceToPlayer)
        {
            animator.Attack();
        }

        protected void Death()
        {
            animator.Death();
            StartCoroutine(DeathCounter());
        }
        IEnumerator DeathCounter()
        {
            yield return new WaitForSeconds(0.25f);
            gameObject.SetActive(false);
        }

        public void TakeHit(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Death();
                return;
            }
            else {
                animator.TakeHit();
                UpdateIndicator();
            }
            
        }

        private void InitIndicators()
        {
            hpText = gameObject.GetComponentInChildren<TMP_Text>();
            hpText.SetText(maxHp.ToString());
        }

    }
}


