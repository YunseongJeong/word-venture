using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpellObject : MonoBehaviour
{
    protected Animator animator;
    protected Deck_Manage.MagicType spellType;
    protected Deck_Manage.MagicType magicType;
    protected SelectableObject target;
    protected float maxTime = 5;
    protected float speed = 10;
    protected Vector3 moveVector;
    protected int damage = 10 + 5 * (Map_scene.MapMove.StagePosition / 2);

    public virtual void InitSpell(
        Deck_Manage.MagicType spellType,
        Deck_Manage.MagicType magicType,
        SelectableObject target
        )
    {
        this.spellType = spellType;
        this.magicType = magicType;
        this.target = target;
    }

    protected virtual void Start()
    {   
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target.gameObject.tag))
        {
            moveVector = Vector3.zero;
            print(collision.gameObject.tag);
            animator.SetTrigger("Hit");
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy.Enemy>().TakeHit(BattleSystem.CalculateDamage(damage, magicType, spellType, collision.gameObject.GetComponent<Enemy.Enemy>().enemyType));
            } else
            {
                collision.GetComponent<Enemy.Player>().TakeHit(BattleSystem.CalculateDamage(damage,magicType, spellType, Deck_Manage.MagicType.Holy));
            }
            
            StartCoroutine(DestoryCounter());
        }
    }

    protected IEnumerator DestoryCounter()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
