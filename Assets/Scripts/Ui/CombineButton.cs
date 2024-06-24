using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineButton : MonoBehaviour
{
    public GameObject CombineZone;
    public Button activateButton; // 버튼 참조

    void Start()
    {
        if (activateButton != null)
        {
            activateButton.onClick.AddListener(OnButtonClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick()
    {
        if (CombineZone != null)
        {
            CombineZone.SetActive(true);
        }
    }
}
