using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombineZone : MonoBehaviour
{
    public List<GameObject> droppedCards = new List<GameObject>();
    public Button activateButton;
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
                activateButton.onClick.AddListener(OnButtonClick);
                ClearDropZone();
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

    public void OnButtonClick()
    {
        List<MagicType> types = GetDroppedCardTypes();

        if (types.Contains(MagicType.Shoot))
        {
            Shoot.GetComponent<Shoot>().shoot(types[1],types[2]);
        }

        if (types.Contains(MagicType.Heal))
        {
            Heal.GetComponent<Heal>().heal(types[1],types[2]);
        }
 
        if (types.Contains(MagicType.Drop))
        {
            Drop.GetComponent<Drop>().drop(types[1],types[2]);
        }

        if (types.Contains(MagicType.Summon))
        {
            Summon.GetComponent<Summon>().summon(types[1],types[2]);
        }
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
