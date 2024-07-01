using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<StageData> stageDataList;
    private StageData currentStageData; 
    private BattleWaveController battleWaveController;
    void Start()
    {
        battleWaveController = FindObjectOfType<BattleWaveController>();

        int stagePosition = StageDataSingleton.Instance.StagePosition;
        LoadStage(stagePosition);
        SetupBattle(currentStageData);
    }

    void LoadStage(int stagePosition)
    {
        foreach (var stageData in stageDataList)
        {
            if (stageData.stageID == stagePosition)
            {
                currentStageData = stageData;
                break;
            }
        }
    }

    void SetupBattle(StageData stageData)
    {
        SetBackground(stageData.background);

        battleWaveController.battleScript = stageData.waveData.enemyWaves[0];
        battleWaveController.Start1();
    }

    void SetBackground(Sprite background)
    {
        GameObject backgroundObject = GameObject.Find("PlainBackground");
        if (backgroundObject != null)
        {
            SpriteRenderer renderer = backgroundObject.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.sprite = background;
            }
        }
    }
}
