using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSpellObject : SpellObject
{

    public override void InitSpell(
    Deck_Manage.MagicType spellType,
    Deck_Manage.MagicType magicType,
    SelectableObject target
    )
    {
        base.InitSpell(spellType, magicType, target);

        StartCoroutine(DestoryCounter());
    }


    protected override void Start()
    {
        base.Start();
    }
}
