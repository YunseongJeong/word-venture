using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deck_Manage;

public class Drop : MonoBehaviour
{
    public GameObject DropfirePrefab;
    public GameObject DropicePrefab;
    public GameObject DroprockPrefab;
    public GameObject DroplightningPrefab;
    public GameObject DropholyPrefab;

    public void drop(Deck_Manage.MagicType magicType, SelectableObject target)
    {
        //GameObject target = GameObject.FindGameObjectWithTag(magicType2.ToString());

        GameObject prefabToInstantiate = null;

        switch (magicType)
        {
            case Deck_Manage.MagicType.Fire:
                prefabToInstantiate = DropfirePrefab;
                break;
            case Deck_Manage.MagicType.Ice:
                prefabToInstantiate = DropicePrefab;
                break;
            case Deck_Manage.MagicType.Rock:
                prefabToInstantiate = DroprockPrefab;
                break;
            case Deck_Manage.MagicType.Lightning:
                prefabToInstantiate = DroplightningPrefab;
                break;
            case Deck_Manage.MagicType.Holy:
                prefabToInstantiate = DropholyPrefab;
                break;
        }
        
        if (prefabToInstantiate != null)
        {
            Vector3 InstantiatePos = target.transform.position + new Vector3 (0f ,10f ,0f) ;
            GameObject obj =  Instantiate(prefabToInstantiate, InstantiatePos , prefabToInstantiate.transform.rotation);
            obj.GetComponent<SpellObject>().InitSpell(MagicType.Drop, magicType, target);
        }
    }
}
