/*
using System.Collections.Generic;
using UnityEngine;
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
        activateButton.gameObject.SetActive(false);
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
                activateButton.gameObject.SetActive(true);
                activateButton.onClick.RemoveAllListeners();
                activateButton.onClick.AddListener(OnButtonClick);
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
            Shoot.GetComponent<Shoot>().shoot(types[1], types[2]);
        }

        if (types.Contains(MagicType.Heal))
        {
            Heal.GetComponent<Heal>().heal(types[1], types[2]);
        }

        if (types.Contains(MagicType.Drop))
        {
            Drop.GetComponent<Drop>().drop(types[1], types[2]);
        }

        if (types.Contains(MagicType.Summon))
        {
            Summon.GetComponent<Summon>().summon(types[1], types[2]);
        }

        ClearDropZone();
    }

    public void ClearDropZone()
    {
        foreach (GameObject card in droppedCards)
        {
            Destroy(card);
        }
        droppedCards.Clear();
        activateButton.gameObject.SetActive(false);
    }
}
*/
//아래는 by gpt
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineZone : MonoBehaviour
{
    public List<GameObject> spellCards = new List<GameObject>();
    public List<GameObject> magicTypeCards = new List<GameObject>();
    public List<GameObject> targetCards = new List<GameObject>();

    public Button activateButton;
    public GameObject Shoot;
    public GameObject Heal;
    public GameObject Drop;
    public GameObject Summon;

    void Start()
    {
        activateButton.gameObject.SetActive(false);
    }

    public void AddCard(GameObject card)
    {
        if (card.CompareTag("Spell") && spellCards.Count < 1)
        {
            spellCards.Add(card);
            card.transform.SetParent(transform);
            card.SetActive(false);
        }
        else if (card.CompareTag("MagicType") && magicTypeCards.Count < 1)
        {
            magicTypeCards.Add(card);
            card.transform.SetParent(transform);
            card.SetActive(false);
        }
        else if (card.CompareTag("Target") && targetCards.Count < 1)
        {
            targetCards.Add(card);
            card.transform.SetParent(transform);
            card.SetActive(false);
        }

        if (spellCards.Count == 1 && magicTypeCards.Count == 1 && targetCards.Count == 1)
        {
            activateButton.gameObject.SetActive(true);
            activateButton.onClick.RemoveAllListeners();
            activateButton.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        if (spellCards.Count == 1 && magicTypeCards.Count == 1 && targetCards.Count == 1)
        {
            MagicType spellType = spellCards[0].GetComponent<Card>().cardType;
            MagicType magicType = magicTypeCards[0].GetComponent<Card>().cardType;
            MagicType targetType = targetCards[0].GetComponent<Card>().cardType;

            if (spellType == MagicType.Shoot)
            {
                Shoot.GetComponent<Shoot>().shoot(magicType, targetType);
            }
            else if (spellType == MagicType.Heal)
            {
                Heal.GetComponent<Heal>().heal(magicType, targetType);
            }
            else if (spellType == MagicType.Drop)
            {
                Drop.GetComponent<Drop>().drop(magicType, targetType);
            }
            else if (spellType == MagicType.Summon)
            {
                Summon.GetComponent<Summon>().summon(magicType, targetType);
            }

            ClearDropZone();
        }
    }

    public void ClearDropZone()
    {
        foreach (GameObject card in spellCards)
        {
            Destroy(card);
        }
        foreach (GameObject card in magicTypeCards)
        {
            Destroy(card);
        }
        foreach (GameObject card in targetCards)
        {
            Destroy(card);
        }
        spellCards.Clear();
        magicTypeCards.Clear();
        targetCards.Clear();
        activateButton.gameObject.SetActive(false);
    }
}
