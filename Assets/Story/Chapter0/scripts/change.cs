using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class change : MonoBehaviour
{
    private List<string> textList = new List<string>() {
        "工作終於告一段落了~",
        "看地址應該在這附近",
        "隊長真是的，寫這麼不清楚",
        "嗯? 衣服嗎..,過去看看好了",
        "…好漂亮",
        "........",
        "？!",
        "!……",
        "看來是我太緊張了",
        "喂，你這什麼姿勢阿",
        "嗯？!"
    };
    public PlayableDirector player;
    private int textIndex = 0;
    public Text text;
    float showTextTime = 1f;
    public void Start()
    {
        SaveLoader.Load();
        player.time = SaveLoader.getLastStorySceneTime();
        textIndex = SaveLoader.getStorySceneRecordTextIndex();
    }
    public void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            this.AnimeEnd();
        }
    }
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
    public void AnimeEnd() {
        Debug.Log("animeEnd");
        SceneManager.LoadScene("BackRoomScenes");
    }
    public void AnimeChange()
    {
        //player.playableGraph.GetRootPlayable(0).SetSpeed(0);
        SaveLoader.setLastStorySceneTime(player.time+0.1);
        SaveLoader.setStorySceneRecordTextIndex(textIndex);
        SceneManager.LoadScene("memory");
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        var a = this.GetComponent<PlayableDirector>();
        Debug.Log(a);
        Debug.Log(player);
        if (scene.name != "Storyscene") return;
        Debug.Log(SaveLoader.getLastStorySceneTime());
        player.time = SaveLoader.getLastStorySceneTime();
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("BackRoomScenes");
    }
}
