using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpellObject : SpellObject
{

    public override void InitSpell(
    Deck_Manage.MagicType spellType,
    Deck_Manage.MagicType magicType,
    SelectableObject target
    )
    {
        base.InitSpell(spellType, magicType, target);
        StartCoroutine(DropAction());
    }


    IEnumerator DropAction()
    {
        moveVector = new Vector3(0, -1 * speed, 0);
        for (float i = 0; i < maxTime;)
        {
            i += 0.01f;
            transform.position += moveVector * 0.01f;
            yield return new WaitForSeconds(0.01f);

        }

        Destroy(gameObject);
    }

    protected override void Start()
    {
        base.Start();
    }
}
