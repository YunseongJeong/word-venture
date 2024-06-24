using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        protected Animator animator;

        protected TMP_Text hpText;
        protected TMP_Text shieldText;

        [SerializeField] protected int id;
        protected int hp = 20;
        protected int maxHp = 20;
        protected float moveDistance = 5;

        protected int shield = 0;

        protected float attackRange = 3;

        private Vector3 tempVector3 = new Vector3();
        float turnTime = 2;

        const int ATTACK = 0;
        const int MOVE = 1;
        const int BLOCK = 2;

        public void InitEnemyData(EnemyData enemyData)
        {
            id = enemyData.id;
            maxHp = enemyData.maxHp;
            moveDistance = enemyData.moveDistance;
            attackRange = enemyData.attackRange;
        }


        void MoveAction(float distanceToPlayer)
        {

            float tempMoveDistance;

            if (distanceToPlayer > moveDistance + attackRange)
            {
                tempMoveDistance = moveDistance;
            } else
            {
                tempMoveDistance = distanceToPlayer - attackRange;
            }

            StartCoroutine(MoveDistance(tempMoveDistance));
        }

        void AttackAction()
        {
            Attack();
        }


        int MakeActionDecision(float distanceToPlayer)
        {
            if (hp < maxHp / 2)
            {
                float random = Random.Range(-1, 1);
                if (random > 0)
                {
                    return BLOCK;
                }
            }

            if (distanceToPlayer > attackRange)
            {
                return MOVE;
            } else
            {
                return ATTACK;
            }
        }

        void UpdateIndicator()
        {
            hpText.SetText(hp.ToString());
            shieldText.SetText(shield.ToString());
        }

        void BlockAction()
        {
            shield += 5;
            UpdateIndicator();
        }

        public void PlayTurnAction(float distanceToPlayer)
        {
            switch (MakeActionDecision(distanceToPlayer))
            {
                case <= ATTACK:
                    AttackAction();
                    break;

                case <= MOVE:
                    MoveAction(distanceToPlayer);
                    break;

                case <= BLOCK:
                    BlockAction();
                    break;
                default:
                    break;
            }
        }


        IEnumerator MoveDistance(float distance)
        {
            float moveSpeed = moveDistance / turnTime;
            float movedDistance = 0;
            while (movedDistance <= distance)
            {
                
                yield return new WaitForSeconds(0.1f);
                movedDistance += moveSpeed * 0.1f;
                Move(-1, moveSpeed * 0.1f);
            }
            StopMove();
        }

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
            InitIndicators();

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

        protected void Move(int direction, float moveStep) {
            FaceToDirection(direction);
            tempVector3 = transform.position;
            tempVector3.x = tempVector3.x + moveStep * direction;
            transform.position = tempVector3;
            animator.SetBool("isMoving", true);
        }

        protected void StopMove()
        {
            animator.SetBool("isMoving", false);
        }

        virtual protected void Attack()
        {
            animator.SetTrigger("Attack");
        }

        protected void Death()
        {
            animator.SetTrigger("Death");
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
                animator.SetTrigger("TakeHit");
            }
            
        }

        private void InitIndicators()
        {
            TMP_Text[] textTemp = gameObject.GetComponentsInChildren<TMP_Text>();
            if (textTemp[0].gameObject.name == "HpIndicator")
            {
                hpText = textTemp[0];
                shieldText = textTemp[1];
            }
            else
            {
                hpText = textTemp[1];
                shieldText = textTemp[0];
            }
            hpText.SetText(maxHp.ToString()) ;
            shieldText.SetText(0.ToString());
        }
    }
}


