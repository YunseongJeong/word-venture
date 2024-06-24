using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{

    public ChatWindowController chatWindowController;

    List<string> storyDialog = new List<string>();


    void Start()
    {
        storyDialog.Add("워드는 아름다운 시골 마을에서 자란 밝고 활기찬 소년이었다.");
        storyDialog.Add("그의 맑은 목소리는 언제나 마을 사람들에게 즐거움을 선사했고, 그의 따뜻한 마음은 많은 사람들에게 사랑받았다.");
        storyDialog.Add("하지만 평화로운 마을에 어느 날 갑자기 어둠이 드리워졌다.");
        StartCoroutine(StoryTelling());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    chatWindowController.UpdateChatStream("나레이터", "평화로운 어느날.");
        //}
    }

    IEnumerator StoryTelling()
    {
        for (int i = 0; i < storyDialog.Count; i++)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            chatWindowController.UpdateChatStream("나레이터", storyDialog[i]);
            yield return new WaitForSeconds(1);
        }
    }

}
