using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ShootfirePrefab;
    public GameObject ShooticePrefab;
    public GameObject ShootrockPrefab;
    public GameObject ShootlightningPrefab;

    public void shoot(Deck_Manage.MagicType magicType1, Deck_Manage.MagicType magicType2)
    {
        GameObject target = GameObject.FindGameObjectWithTag(magicType2.ToString());

        GameObject prefabToInstantiate = null;

        switch (magicType1)
        {
            case Deck_Manage.MagicType.Fire:
                prefabToInstantiate = ShootfirePrefab;
                break;
            case Deck_Manage.MagicType.Ice:
                prefabToInstantiate = ShooticePrefab;
                break;
            case Deck_Manage.MagicType.Rock:
                prefabToInstantiate = ShootrockPrefab;
                break;
            case Deck_Manage.MagicType.Lightning:
                prefabToInstantiate = ShootlightningPrefab;
                break;
        }

        if (prefabToInstantiate != null)
        {
            Instantiate(prefabToInstantiate, target.transform.position, Quaternion.identity);
        }
    }    
}