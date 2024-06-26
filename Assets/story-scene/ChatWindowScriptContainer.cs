using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;


[Serializable]
public struct ChatWindowData
{
    [SerializeField] public string name;
    [SerializeField] public string text;
    [SerializeField] public int background;
}


[CreateAssetMenu]
public class ChatWindowScriptContainer : ScriptableObject
{

    [SerializeField] List<ChatWindowData> script = new List<ChatWindowData>();

    public ChatWindowData GetScriptData(int n)
    {
        if (n == -1)
        {
            return new ChatWindowData();
        }

        return script[n];
    }

    public int GetScriptNum()
    {
        return script.Count;
    }
}
