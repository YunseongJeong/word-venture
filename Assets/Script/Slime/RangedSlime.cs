using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class RangedEnemy : Enemy
    {
        [SerializeField] GameObject projectile;
        
        void Start()
        {
            base.Start();
        }

        public override void Attack(float distanceToPlayer)
        {
            animator.RangeAttack();
            GameObject projectile_object = Instantiate(projectile, transform.position,Quaternion.identity);
            projectile.GetComponent<EnemyProjectile>().InitProjectileDamage(damage);
        }
    }
}
