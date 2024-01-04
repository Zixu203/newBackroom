using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class dialogue : MonoBehaviour
{
    private List<string> textList = new List<string>() {
    "你發現了嗎? 這裡不是原來的世界",
    "你們是誰?",
    "我們是被傳送到這裡的受害者聯盟",
    "而這裡是類現世，這裡雖然有現實中的資源",
    "但是，一個人都沒有",
    "那你們在這裡有發現什麼?",
    "如果想從我們這獲取情報，就要加入我們組織",
    "(現在情報比較重要，先答應好了)",
    "好，我加入你們",
    "加入我們組織需要做簡單的測試",
    "測試內容是?",
    "幫我們殺一個人",
    "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
    };
    private List<string> name = new List<string>() {
        "白夜",
        "勝男" 
    };
    private int[] store = new int[] {1,0,1,1,1,0,1,0,0,1,0,1,0};
    public PlayableDirector player;
    private int textIndex = 0;
    public Text text;
    public Text text2;
    public Image image;
    public Sprite first;
    public Sprite second;
    float showTextTime = 1f;
    public void showText()
    {
        text2.text = name[store[textIndex]];
        if (store[textIndex] == 0)
            image.GetComponent<Image>().sprite = first;
        else
            image.GetComponent<Image>().sprite = second;
        StartCoroutine("typingText", textList[textIndex]);
        textIndex++;
    }
    private IEnumerator typingText(string str)
    {
        text.text = "";
        foreach (var c in str)
        {
            text.text += c;
            yield return new WaitForSeconds(showTextTime / str.Length);
        }
        player.playableGraph.GetRootPlayable(0).SetSpeed(0);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        player.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
    public void AnimeChange()
    {
        SceneManager.LoadScene("endScenes");
    }
}
