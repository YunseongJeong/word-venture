using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class MagicEnemy : Enemy
    {
        [SerializeField] GameObject fireShoot;
        
        void Start()
        {
            base.Start();
            attackRange = 20;
        }

        public override void Attack()
        {
            base.Attack();
            Instantiate(fireShoot, transform.position,Quaternion.identity);
        }

    }
}
