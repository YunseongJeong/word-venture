using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{

    public class ShieldEnemy : Enemy
    {
        
        void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("Attack"))
            {
                hp -= 1;
            } 
            if (other.CompareTag("Heal"))
            {
                hp += 1;
            }
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        } 
    }
}