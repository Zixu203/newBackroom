using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue {
    public bool isEnd;
    public List<string> strings;
    public int nextDialogueIndex;
    public bool haveOption;
    public string talker;
    
    public Dialogue(List<string> strings, int nextDialogueIndex, bool isEnd, string talker, bool haveOption){
        this.strings = strings;
        this.nextDialogueIndex = nextDialogueIndex;
        this.isEnd = isEnd;
        this.talker = talker;
        this.haveOption = haveOption;
    }
}
// public class DialogueNode {
//     public BaseEntity baseEntity;
//     Dialogue dialogue;
//     public string text;
//     public int nextIndex;
//     public DialogueNode nextNode(int index) {
//         return new DialogueNode();
//     }
// }

[Serializable]
public class DialogueSystem{

    public Image dialogueBox;
    public Text dialogueText;
    public Text dialogueTalker;
    public Image dialogueImage;
    public Button button0;
    public Button button1;
    public bool needEndDialogue;
    public bool isInOption;
    BaseEntity currentDialogue;
    int currentIndex;

    Dictionary<BaseEntity, List<Dialogue>> keyValuePairs;

    public void init(){
        // string npcString = "1413566-photo-1-source-small";
        string npcString = "heshi";

        keyValuePairs = new Dictionary<BaseEntity, List<Dialogue>>(){
            [GameController.getInstance.npcs[0]] = new List<Dialogue>() {
                new Dialogue(new List<string>() {
                    "幫我裝水",
                    npcString
                }, 1, false, GameController.getInstance.npcs[0].name, false),
                new Dialogue(new List<string>() {
                    "拜託",
                    npcString,
                    "要",
                    "不要"
                }, 1, false, GameController.getInstance.npcs[0].name, true),
                new Dialogue(new List<string>(){
                    "謝拉啊啊啊啊",
                    npcString
                }, 4, false, GameController.getInstance.npcs[0].name, false),
                new Dialogue(new List<string>(){
                    "為什麼不要 嗚嗚",
                    npcString
                }, 5, false, GameController.getInstance.npcs[0].name, false),
                new Dialogue(new List<string>() {
                    "你拿回來了喔",
                    npcString             
                }, 0, true, GameController.getInstance.npcs[0].name, false),
                new Dialogue(new List<string>() {
                    "不理你了",
                    npcString             
                }, 0, true, GameController.getInstance.npcs[0].name, false)
            },

            [GameController.getInstance.npcs[1]] = new List<Dialogue>() {
                new Dialogue(new List<string>() {
                    "你是張雨生嗎?",
                    npcString,
                    "是",
                    "不是"
                }, 0, false, GameController.getInstance.npcs[1].name,true),
                new Dialogue(new List<string>() {
                    "我是張雨生",
                    npcString
                }, 3, false, GameController.getInstance.npcs[1].name,false),
                new Dialogue(new List<string>() {
                    "不是，我是吳克蘭",
                    npcString
                }, 4, false, GameController.getInstance.npcs[1].name,false),
                new Dialogue(new List<string>() {
                    "我是歌手",
                    npcString
                }, 0, true, GameController.getInstance.npcs[1].name,false),
                new Dialogue(new List<string>() {
                    "我是丹麥記者",
                    npcString
                }, 0, true, GameController.getInstance.npcs[1].name,false)
            }
        };
        
        
        dialogueBox = GameObject.Find("Dialogue").transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        dialogueText = GameObject.Find("Dialogue").transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
        dialogueTalker = GameObject.Find("Dialogue").transform.GetChild(2).GetComponent<UnityEngine.UI.Text>();
        dialogueImage = GameObject.Find("Dialogue").transform.GetChild(3).GetComponent<UnityEngine.UI.Image>();
        button0 = GameObject.Find("Dialogue").transform.GetChild(4).GetComponent<UnityEngine.UI.Button>();
        button1 = GameObject.Find("Dialogue").transform.GetChild(5).GetComponent<UnityEngine.UI.Button>();
        button0.onClick.AddListener(Button0OnClick);
        button1.onClick.AddListener(Button1OnClick);
    }
    public DialogueSystem() {
        
    }
    public void Start(){
    }

    public void StartDialogue(BaseEntity baseEntity) {
        GameController.getInstance.targetPlayer.isInDialogue = true;
        currentDialogue = baseEntity;
        currentIndex = SaveLoader.getEntityDialogueIndex(currentDialogue);
        Dialogue dialogue = this.keyValuePairs[currentDialogue][currentIndex];

        SetObjectActive(true);

        dialogueText.text = dialogue.strings[0];
        dialogueTalker.text = dialogue.talker;
        
        dialogueImage.sprite = Resources.Load<Sprite>(dialogue.strings[1]);

        if(dialogue.haveOption){
            button0.gameObject.SetActive(true);
            button1.gameObject.SetActive(true);
            button0.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = dialogue.strings[2];
            button1.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = dialogue.strings[3];
            currentDialogue = baseEntity;
            isInOption = true;
        }
        else if(dialogue.isEnd) needEndDialogue = true;
        else currentIndex = dialogue.nextDialogueIndex;
    }
    public bool ContinueDialogue(){

        if(!isInOption){

            Dialogue dialogue = this.keyValuePairs[currentDialogue][currentIndex];

            if(needEndDialogue){
                needEndDialogue = false;
                EndDialogue(currentDialogue, dialogue.nextDialogueIndex);
                return true;
            }
            
            dialogueText.text = dialogue.strings[0];
            dialogueTalker.text = dialogue.talker;
            dialogueImage.sprite = Resources.Load<Sprite>(dialogue.strings[1]);

            if(dialogue.haveOption){
                button0.gameObject.SetActive(true);
                button1.gameObject.SetActive(true);
                button0.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = dialogue.strings[2];
                button1.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = dialogue.strings[3];
                isInOption = true;
            }
            else if(dialogue.isEnd) needEndDialogue = true;      
            else currentIndex = dialogue.nextDialogueIndex;  
        }
        
        return false;    
    }
    public void Button0OnClick(){
        currentIndex++;
        button0.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        isInOption = false;
        ContinueDialogue();
    }
    public void Button1OnClick(){
        currentIndex+=2;
        button0.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        isInOption = false;
        ContinueDialogue();
        
    }
    private void EndDialogue(BaseEntity baseEntity, int index){
        SetObjectActive(false);
        SaveLoader.setEntityDialogueIndex(baseEntity, index); 
    }

    private void SetObjectActive(bool b){
        dialogueBox.gameObject.SetActive(b);
        dialogueText.gameObject.SetActive(b);
        dialogueTalker.gameObject.SetActive(b);
        dialogueImage.gameObject.SetActive(b);
    }
    
}
