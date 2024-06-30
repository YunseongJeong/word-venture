using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpellObj : MonoBehaviour
{
    Animator animator;
    Deck_Manage.MagicType spellType;
    Deck_Manage.MagicType magicType;
    SelectableObject target;

    public void InitSpell(
        Deck_Manage.MagicType spellType,
        Deck_Manage.MagicType magicType,
        SelectableObject target)
    {

        this.spellType = spellType;
        this.magicType = magicType;
        this.target = target;

        if (this.spellType == Deck_Manage.MagicType.Summon)
        {
            StartCoroutine(DestoryCounter());
            return;
        }

        if (this.spellType == Deck_Manage.MagicType.Drop)
        {
            print("tlqkf");
            moveVector = new Vector3(0, -1 * speed, 0);
        } else if (this.spellType == Deck_Manage.MagicType.Shoot)
        {
            moveVector = new Vector3(speed, 0, 0);
        }

        if (this.spellType == Deck_Manage.MagicType.Shoot || this.spellType == Deck_Manage.MagicType.Drop)
        {
            StartCoroutine(ShootAction());
        }
    }
    float maxTime = 5;


    IEnumerator ShootAction()
    {
        for (float i = 0; i < maxTime;)
        {
            i += 0.01f;
            transform.position += moveVector * 0.01f;
            yield return new WaitForSeconds(0.01f);

        }

        Destroy(gameObject);
    }
    float speed = 10;
    Vector3 moveVector;
    int damage = 1;

    public void InitProjectileDamage(int damage)
    {
        this.damage = damage;
    }

    void Start()
    {
        
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            moveVector = Vector3.zero;
            print(collision.gameObject.tag);
            animator.SetTrigger("Hit");
            collision.GetComponent<Enemy.Enemy>().TakeHit(damage);
            StartCoroutine(DestoryCounter());
        }
    }
    IEnumerator DestoryCounter()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
