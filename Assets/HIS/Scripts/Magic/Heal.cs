using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject HealfirePrefab;
    public GameObject HealicePrefab;
    public GameObject HealrockPrefab;
    public GameObject HeallightningPrefab;

    public void heal(Deck_Manage.MagicType magicType1, Deck_Manage.MagicType magicType2, SelectableObject target)
    {

        GameObject prefabToInstantiate = null;

        switch (magicType1)
        {
            case Deck_Manage.MagicType.Fire:
                prefabToInstantiate = HealfirePrefab;
                break;
            case Deck_Manage.MagicType.Ice:
                prefabToInstantiate = HealicePrefab;
                break;
            case Deck_Manage.MagicType.Rock:
                prefabToInstantiate = HealrockPrefab;
                break;
            case Deck_Manage.MagicType.Lightning:
                prefabToInstantiate = HeallightningPrefab;
                break;
        }

        if (prefabToInstantiate != null)
        {
            Instantiate(prefabToInstantiate, target.transform.position, Quaternion.identity);
        }
    }
}
