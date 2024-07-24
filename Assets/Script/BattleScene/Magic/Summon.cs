using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deck_Manage;

public class Summon : MonoBehaviour
{
    public GameObject player;
    public GameObject SummonfirePrefab;
    public GameObject SummonicePrefab;
    public GameObject SummonrockPrefab;
    public GameObject SummonlightningPrefab;
    public GameObject SummonHolyPrefab;

    public void summon(MagicType magicType, SelectableObject target)
    {

        GameObject prefabToInstantiate = null;

        switch (magicType)
        {
            case MagicType.Fire:
                prefabToInstantiate = SummonfirePrefab;
                break;
            case MagicType.Ice:
                prefabToInstantiate = SummonicePrefab;
                break;
            case MagicType.Rock:
                prefabToInstantiate = SummonrockPrefab;
                break;
            case MagicType.Lightning:
                prefabToInstantiate = SummonlightningPrefab;
                break;
            case MagicType.Holy:
                prefabToInstantiate = SummonHolyPrefab;
                break;
        }

        if (prefabToInstantiate != null)
        {
            GameObject obj = Instantiate(prefabToInstantiate, target.transform.position + new Vector3(0, -1 * target.transform.position.y, 0), Quaternion.identity);
            obj.GetComponent<SpellObject>().InitSpell(MagicType.Summon, magicType, target);
        }
    }
}
