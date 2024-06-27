using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] CombineZone combineZone;

    public void GetCard(GameObject card)
    {
        combineZone.AddCard(card);
    }
}
