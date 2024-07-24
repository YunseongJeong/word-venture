using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deck_Manage;
using Enemy;
public class Shoot : MonoBehaviour
{
    public GameObject ShootfirePrefab;
    public GameObject ShooticePrefab;
    public GameObject ShootrockPrefab;
    public GameObject ShootlightningPrefab;
    public GameObject ShootHolyPrefab;

    public void shoot(MagicType magicType, SelectableObject target)
    {

        GameObject prefabToInstantiate = null;

        switch (magicType)
        {
            case MagicType.Fire:
                prefabToInstantiate = ShootfirePrefab;
                break;
            case MagicType.Ice:
                prefabToInstantiate = ShooticePrefab;
                break;
            case MagicType.Rock:
                prefabToInstantiate = ShootrockPrefab;
                break;
            case MagicType.Lightning:
                prefabToInstantiate = ShootlightningPrefab;
                break;
            case MagicType.Holy:
                prefabToInstantiate = ShootHolyPrefab;
                break;
        }

        if (prefabToInstantiate != null)
        {
            GameObject obj = Instantiate(prefabToInstantiate, Enemy.Player.PlayerInt().transform.position, prefabToInstantiate.transform.rotation);
            
            obj.GetComponent<SpellObject>().InitSpell(MagicType.Shoot, magicType, target);
        }
    }    
}