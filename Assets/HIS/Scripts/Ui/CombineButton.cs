using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombineButton : MonoBehaviour
{
    public GameObject CombineZone;
    public Button activateButton; // 버튼 참조

    //void Start()
    //{
    //    if (activateButton != null)
    //    {
    //        activateButton.onClick.AddListener(OnButtonClick);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (!CombineZone.activeSelf)
        {
            CombineZone.SetActive(true);
        }
        else if (CombineZone.activeSelf)
        {
            CombineZone.SetActive(false);
        }
    }
}
