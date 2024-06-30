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

    public void shoot(MagicType magicType1, MagicType magicType2, SelectableObject target)
    {

        GameObject prefabToInstantiate = null;

        switch (magicType1)
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
        }

        if (prefabToInstantiate != null)
        {
            GameObject obj = Instantiate(prefabToInstantiate, PlayerTestForEnemy.Player().transform.position + new Vector3(0, 1), prefabToInstantiate.transform.rotation);
            
            obj.GetComponent<SpellObj>().InitSpell(MagicType.Shoot, magicType1, target);
        }
    }    
}