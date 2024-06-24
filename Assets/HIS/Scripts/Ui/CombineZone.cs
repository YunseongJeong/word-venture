using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombineZone : MonoBehaviour
{
    public List<GameObject> droppedCards = new List<GameObject>();
    public GameObject activateButton;
    public GameObject Shoot;
    public GameObject Heal;
    public GameObject Drop;
    public GameObject Summon;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(GameObject card)
    {
        if (droppedCards.Count < 3)
        {
            droppedCards.Add(card);
            card.transform.SetParent(transform);
            card.SetActive(false);

            if (droppedCards.Count == 3)
            {
                List<MagicType> types = GetDroppedCardTypes();
                
                if (types.Contains(MagicType.Shoot))
                {
                    Shoot.GetComponent<Shoot>().shoot();
                }

                if (types.Contains(MagicType.Heal))
                {
                    Heal.GetComponent<Heal>().heal();
                }

                if (types.Contains(MagicType.Drop))
                {
                    Drop.GetComponent<Drop>().drop();
                }

                if (types.Contains(MagicType.Summon))
                {
                    Summon.GetComponent<Summon>().summon();
                }
                
                activateButton.SetActive(true);
            }
        }
    }

    public List<MagicType> GetDroppedCardTypes()
    {
        List<MagicType> types = new List<MagicType>();
        foreach (GameObject card in droppedCards)
        {
            Card cardComponent = card.GetComponent<Card>();
            if (cardComponent != null)
            {
                types.Add(cardComponent.cardType);
            }
        }
        return types;
    }

    public void ClearDropZone()
    {
        foreach (GameObject card in droppedCards)
        {
            Destroy(card);
        }
        droppedCards.Clear();
    }
}
