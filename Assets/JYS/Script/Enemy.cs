using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        protected Animator animator;

        protected int hp = 20;
        protected int maxHp = 20;
        protected float moveDistance = 5;

        protected float attackRange = 5;

        private Vector3 tempVector3 = new Vector3();
        float turnTime = 2;

        const int ATTACK = 0;
        const int MOVE = 1;



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
            print(distanceToPlayer);
            if (distanceToPlayer > attackRange)
            {
                print("Move");
                return MOVE;
            } else
            {
                return ATTACK;
            }
        }

        public void PlayTurnAction(float distanceToPlayer)
        {
            switch (MakeActionDecision(distanceToPlayer))
            {
                case <= 0:
                    AttackAction();
                    break;

                case <= 1:
                    MoveAction(distanceToPlayer);
                    break;

                default:
                    break;
            }
        }


        IEnumerator MoveDistance(float distance)
        {
            float moveSpeed = moveDistance / turnTime;
            float movedDistance = 0;
            while (movedDistance <= moveDistance)
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
            print(moveStep);
            print(direction);
            print(moveStep * direction);
            tempVector3.x = tempVector3.x + moveStep * direction;
            transform.position = tempVector3;
            animator.SetBool("isMoving", true);
        }

        protected void StopMove()
        {
            animator.SetBool("isMoving", false);
        }

        protected void Attack()
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

    }
}


