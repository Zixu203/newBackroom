using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue {
    public string TalkerName {get; set;}
    public string TalkerPicPath {get; set;}
    public string TalkString {get; set;}
    public int NextDialogueIndex {get; set;}
    public List<Tuple<string, int>> ResponseTextAndNext {get; set;}
    public bool IsEnd {get; set;}
    public Dialogue(string Talker, string TalkerPicPath, string TalkString, int NextDialogueIndex, bool IsEnd)
        : this(Talker, TalkerPicPath, TalkString, NextDialogueIndex, new List<Tuple<string, int>>(), IsEnd) {
    }
    public Dialogue(string Talker, string TalkerPicPath, string TalkString, List<Tuple<string, int>> ResponseTextAndNext)
        : this(Talker, TalkerPicPath, TalkString, -1, ResponseTextAndNext, false) {
    }
    private Dialogue(string Talker, string TalkerPicPath, string TalkString, int NextDialogueIndex, List<Tuple<string, int>> ResponseTextAndNext, bool IsEnd) {
        this.TalkerName = Talker;
        this.TalkerPicPath = TalkerPicPath;
        this.TalkString = TalkString;
        this.NextDialogueIndex = NextDialogueIndex;
        this.ResponseTextAndNext = ResponseTextAndNext;
        this.IsEnd = IsEnd;
    }    
}

[Serializable]
public class DialogueSystem {
    [SerializeField] private List<BaseEntity> npcs;
    [SerializeField] private Image dialogueBox;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text dialogueTalker;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private List<Button> ResponceButtons;
    [SerializeField] private List<Text> ResponceButtonTexts;
    private BaseEntity currentDialogue;
    private int currentIndex;
    private Dictionary<BaseEntity, List<Dialogue>> EntityToDialogues;
    public Action ClickAction = null;
    public void init(){
        // string npcString = "1413566-photo-1-source-small";
        string npcPicFileName = "heshi";

        this.EntityToDialogues = new Dictionary<BaseEntity, List<Dialogue>>(){
            [this.npcs[0]] = new List<Dialogue>() {
                new Dialogue(
                    this.npcs[0].name,
                    npcPicFileName,
                    "幫我裝水",
                    1,
                    false
                ),
                new Dialogue(
                    this.npcs[0].name,
                    npcPicFileName,
                    "拜託",
                    new List<Tuple<string, int>>(){
                        new Tuple<string, int>("要", 2),
                        new Tuple<string, int>("不要", 3)
                    }
                ),
                new Dialogue(
                    this.npcs[0].name,
                    npcPicFileName,
                    "謝拉啊啊啊啊",
                    4,
                    false
                ),
                new Dialogue(
                    this.npcs[0].name,
                    npcPicFileName,
                    "為什麼不要 嗚嗚",
                    5,
                    false
                ),
                new Dialogue(
                    this.npcs[0].name,
                    npcPicFileName,
                    "你拿回來了喔",
                    0,
                    true
                ),
                new Dialogue(
                    this.npcs[0].name,
                    npcPicFileName,
                    "不理你了",
                    0,
                    true
                )
            },

            [this.npcs[1]] = new List<Dialogue>() {
                new Dialogue(
                    this.npcs[1].name,
                    npcPicFileName,
                    "你是張雨生嗎?",
                    new List<Tuple<string, int>>(){
                        new Tuple<string, int>("是", 1),
                        new Tuple<string, int>("不是", 2)
                    }
                ),
                new Dialogue(
                    this.npcs[1].name,
                    npcPicFileName,
                    "我是張雨生",
                    3,
                    false
                ),
                new Dialogue(
                    this.npcs[1].name,
                    npcPicFileName,
                    "不是，我是吳克蘭",
                    4,
                    false
                ),
                new Dialogue(
                    this.npcs[1].name,
                    npcPicFileName,
                    "我是歌手",
                    0,
                    true
                ),
                new Dialogue(
                    this.npcs[1].name,
                    npcPicFileName,
                    "我是丹麥記者",
                    0,
                    true
                )
            }
        };
    }

    public void StartDialogue(BaseEntity baseEntity) {
        GameController.getInstance.targetPlayer.isInDialogue = true;
        this.currentDialogue = baseEntity;
        this.currentIndex = SaveLoader.getEntityDialogueIndex(this.currentDialogue);
        SetObjectActive(true);
        this.ContinueDialogue();
    }
    private void ContinueDialogue(){
        Dialogue dialogue = this.EntityToDialogues[currentDialogue][currentIndex];
        this.dialogueText.text = dialogue.TalkString;
        this.dialogueTalker.text = dialogue.TalkerName;
        this.dialogueImage.sprite = Resources.Load<Sprite>(dialogue.TalkerPicPath);

        if(dialogue.ResponseTextAndNext.Count != 0) {
            for (int i = 0; i < dialogue.ResponseTextAndNext.Count; ++i) {
                this.ResponceButtons[i].gameObject.SetActive(true);
                this.ResponceButtonTexts[i].text = dialogue.ResponseTextAndNext[i].Item1;
                this.ResponceButtons[i].onClick.RemoveAllListeners();
                int a = i;
                this.ResponceButtons[i].onClick.AddListener(() => {
                    this.currentIndex = dialogue.ResponseTextAndNext[a].Item2;
                    this.ResponceButtons.ForEach(x=>x.gameObject.SetActive(false));
                    ContinueDialogue();
                });
            }
            this.ClickAction = null;
        } else if(dialogue.IsEnd) {
            this.ClickAction = () => {
                EndDialogue(currentDialogue, dialogue.NextDialogueIndex);
            };
        } else {
            this.ClickAction = () => {
                this.currentIndex = dialogue.NextDialogueIndex;
                this.ContinueDialogue();
            };
        }
    }
    private void EndDialogue(BaseEntity baseEntity, int index){
        this.ClickAction = null;
        SetObjectActive(false);
        GameController.getInstance.targetPlayer.isInDialogue = false;
        SaveLoader.setEntityDialogueIndex(baseEntity, index); 
    }

    private void SetObjectActive(bool b){
        dialogueBox.gameObject.SetActive(b);
        dialogueText.gameObject.SetActive(b);
        dialogueTalker.gameObject.SetActive(b);
        dialogueImage.gameObject.SetActive(b);
    }

}
