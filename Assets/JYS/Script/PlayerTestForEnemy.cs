using System.Collections;
using System.Collections.Generic;
using Enemy;
using TMPro;
using UnityEngine;

namespace Enemy{
    public class PlayerTestForEnemy : MonoBehaviour
    {

        public static PlayerTestForEnemy Player()
        {
            return instance;
        }

        static PlayerTestForEnemy instance;

        protected TMP_Text hpText;
        protected TMP_Text shieldText;

        protected int hp = 100;
        protected int maxHp = 100;
        protected int damage;

        public int shield = 0;

        public void UpdateIndicator()
        {
            hpText.SetText(hp.ToString());
            shieldText.SetText(shield.ToString());
        }

        private void Awake()
        {
            InitIndicators();
            instance = this;
        }



        protected void Death()
        {
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
            else
            {
                print(hp);
                UpdateIndicator();
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
            hpText.SetText(maxHp.ToString());
            shieldText.SetText(0.ToString());
        }
    }
}

