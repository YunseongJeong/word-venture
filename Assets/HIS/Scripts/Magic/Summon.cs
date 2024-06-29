using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public void summon(Deck_Manage.MagicType magicType1, Deck_Manage.MagicType magicType2, SelectableObject target)
    {
        print("summon" + magicType1.ToString() + magicType2.ToString());
    }
}
