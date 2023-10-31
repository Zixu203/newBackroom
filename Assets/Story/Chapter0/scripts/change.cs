using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
public class change : MonoBehaviour
{
    private List<string> textList = new List<string>() {
"工作終於告一段落了~",
"看地址應該在這附近",
"隊長真是的，寫這麼不清楚",
"嗯? 衣服嗎..,過去看看好了",
"…好漂亮",
"？!",
"!……",
"看來是我太緊張了",
"喂，你這什麼姿勢阿",
"嗯？!"
    };
    public PlayableDirector player;
    private int textIndex = 0;
    public TextMeshProUGUI text;
    float showTextTime = 1f;
    public void showText()
    {
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
}
