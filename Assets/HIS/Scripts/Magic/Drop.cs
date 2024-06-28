using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject DropfirePrefab;
    public GameObject DropicePrefab;
    public GameObject DroprockPrefab;
    public GameObject DroplightningPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drop(Deck_Manage.MagicType magicType1, Deck_Manage.MagicType magicType2)
    {
        GameObject target = GameObject.FindGameObjectWithTag(magicType2.ToString());

        GameObject prefabToInstantiate = null;

        switch (magicType1)
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
        }

        if (prefabToInstantiate != null)
        {
            Vector3 InstantiatePos = target.transform.position + new Vector3 (0f ,30f ,0f) ;
            Instantiate(prefabToInstantiate, InstantiatePos , Quaternion.identity);
        }
    }
}
