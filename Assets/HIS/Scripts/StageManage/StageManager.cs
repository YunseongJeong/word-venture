using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        int StagePosition = StageData.Instance.StagePosition;

        SetupBattle(StagePosition);
    }

    void SetupBattle(int StagePosition)
    {
        Debug.Log($"Stage ID: {stageID}, Stage Name: {stageName}, Stage Position: {stagePosition}");
    }
}
