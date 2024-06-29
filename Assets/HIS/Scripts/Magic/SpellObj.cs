using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpellObj : MonoBehaviour
{
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

        if (this.spellType == Deck_Manage.MagicType.Shoot)
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
        moveVector = new Vector3(speed, 0, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            print(collision.gameObject.tag);
            collision.GetComponent<Enemy.Enemy>().TakeHit(damage);
            Destroy(gameObject);
        }
    }
}
