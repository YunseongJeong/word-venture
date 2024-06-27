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
        }

        public override void Attack(float distanceToPlayer)
        {
            base.Attack(distanceToPlayer);
            Instantiate(fireShoot, transform.position,Quaternion.identity); 
        }

    }
}
