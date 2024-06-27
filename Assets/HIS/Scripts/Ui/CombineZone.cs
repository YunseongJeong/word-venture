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
        }
        else if (card.CompareTag("MagicType") && magicTypeCards.Count < 1)
        {
            magicTypeCards.Add(card);
        }
        else if (card.CompareTag("Target") && targetCards.Count < 1)
        {
            targetCards.Add(card);
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
            Deck_Manage.MagicType spellType = spellCards[0].GetComponent<Deck_Manage.Card>().cardType;
            Deck_Manage.MagicType magicType = magicTypeCards[0].GetComponent<Deck_Manage.Card>().cardType;
            Deck_Manage.MagicType targetType = targetCards[0].GetComponent<Deck_Manage.Card>().cardType;



            if (spellType == Deck_Manage.MagicType.Shoot)
            {
                
                Shoot.GetComponent<Shoot>().shoot(magicType, targetType);
            }
            else if (spellType == Deck_Manage.MagicType.Heal)
            {
                Heal.GetComponent<Heal>().heal(magicType, targetType);
            }
            else if (spellType == Deck_Manage.MagicType.Drop)
            {
                Drop.GetComponent<Drop>().drop(magicType, targetType);
            }
            else if (spellType == Deck_Manage.MagicType.Summon)
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
            if(card != null)
                Destroy(card);
        }
        foreach (GameObject card in magicTypeCards)
        {
            if(card != null)
                Destroy(card);
        }
        foreach (GameObject card in targetCards)
        {
            if(card != null)
                Destroy(card);
        }
        spellCards.Clear();
        magicTypeCards.Clear();
        targetCards.Clear();
        activateButton.gameObject.SetActive(false);
    }
}
