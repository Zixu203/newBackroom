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
    "�A�o�{�F��? �o�̤��O��Ӫ��@��",
    "�A�̬O��?",
    "�ڭ̬O�Q�ǰe��o�̪����`���p��",
    "�ӳo�̬O���{�@�A�o�����M���{�ꤤ���귽",
    "���O�A�@�ӤH���S��",
    "���A�̦b�o�̦��o�{����?",
    "�p�G�Q�q�ڭ̳o��������A�N�n�[�J�ڭ̲�´",
    "(�{�b����������n�A�������n�F)",
    "�n�A�ڥ[�J�A��",
    "�[�J�ڭ̲�´�ݭn��²�檺����",
    "���դ��e�O?",
    "���ڭ̱��@�ӤH",
    "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
    };
    private List<string> name = new List<string>() {
        "�թ]",
        "�Өk" 
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
