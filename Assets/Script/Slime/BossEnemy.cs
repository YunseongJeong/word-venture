using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class BossEnemy : Enemy
    {
        [SerializeField] GameObject fireShoot;

        void Start()
        {
            base.Start();
        }

        public override void Attack(float distanceToPlayer)
        {
            base.Attack(distanceToPlayer);
            if (distanceToPlayer < attackRange)
            {
                Player.PlayerInt().TakeHit(damage);
            }
        }
        protected override void StopMove()
        {
            base.StopMove();
            animator.RangeAttack();
            GameObject projectile = Instantiate(fireShoot, transform.position, Quaternion.identity);
            projectile.GetComponent<EnemyProjectile>().InitProjectileDamage((int) (damage * 0.7f));
        }


    }
}


