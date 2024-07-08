using System.Collections;
using System.Collections.Generic;
using Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemy{
    public class Player : MonoBehaviour
    {
        Animator animator;

        public static Player PlayerInt()
        {
            return instance;
        }

        static Player instance;

        protected TMP_Text hpText;

        protected int hp = 100;
        protected int maxHp = 100;
        protected int damage;

        public int shield = 0;

        public void UpdateIndicator()
        {
            hpText.SetText(hp.ToString());
        }

        private void Awake()
        {
            InitIndicators();
            animator = GetComponent<Animator>();
            instance = this;
        }

        public void AttackAnima()
        {
            animator.SetTrigger("Attack");
        }


        protected void Death()
        {
            animator.SetTrigger("Death");
            //gameObject.SetActive(false);
            SceneManager.LoadScene("GameOverScene");
        }

        public void TakeHit(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Death();
                return;
            }
            else if (damage > 0)
            {
                animator.SetTrigger("GetHit");
                UpdateIndicator();
            } else
            {
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

