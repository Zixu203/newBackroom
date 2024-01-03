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
    [SerializeField] private Image dialogueBox;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text dialogueTalker;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private List<Button> ResponceButtons;
    [SerializeField] private List<Text> ResponceButtonTexts;
    private BaseNPC currentDialogueNPC;
    private int currentIndex;
    private Dictionary<string, List<Dialogue>> EntityToDialogues;
    public Action ClickAction = null;
    public void init(){
        // string npcString = "1413566-photo-1-source-small";
        string npcPicFileName = "heshi";

        this.EntityToDialogues = new Dictionary<string, List<Dialogue>>(){
            ["htead"] = new List<Dialogue>() {
                new Dialogue(
                    "赫塔德",
                    npcPicFileName,
                    "喔，你是新來的?",
                    1,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "你好，我叫白夜",
                    2,
                    false
                ),
                new Dialogue(
                    "赫塔德",
                    npcPicFileName,
                    "我叫赫塔德，你應該需要導遊吧，這裡不安全，先去安全的地方再聊吧。",
                    3,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "(這個人有點奇怪，要小心一點。)",
                    4,
                    true
                ),
                new Dialogue(
                    "赫塔德",
                    npcPicFileName,
                    "你想問什麼?",
                    5,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "這裡是哪裡?",
                    6,
                    false
                ),
                new Dialogue(
                    "赫塔德",
                    npcPicFileName,
                    "我也不知道，但這裡的空間是透過門連接在一起的。",
                    7,
                    false
                ),
                new Dialogue(
                    "赫塔德",
                    npcPicFileName,
                    "只要穿過門就可以傳送到其他空間。",
                    8,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "那你知道要怎麼出去嗎?",
                    9,
                    false
                ),
                new Dialogue(
                    "赫塔德",
                    npcPicFileName,
                    "可能有一扇門連接著，你只要找到它就能回去。",
                    10,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "好，那我現在去找。",
                    0,
                    true
                ),
            },

            ["baiye"] = new List<Dialogue>() {
                new Dialogue(
                    "白夜",
                    "baiye",
                    "頭好痛...",
                    1,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "這裡是哪裡?",
                    2,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "我記得我剛剛還在逛街。",
                    3,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "明明才剛放假，最近總是遇到怪事。",
                    4,
                    false
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "算了，先去附近看看。",
                    5,
                    true
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "(前面有一個人，從他那獲取一點資訊好了。)",
                    6,
                    true
                ),
                new Dialogue(
                    "白夜",
                    "baiye",
                    "(雖然一起行動比較好，但不知道他的身分，還是自己探察比較保險。)",
                    0,
                    true
                ),
            }
            
        };
    }

    public void StartDialogue(BaseNPC baseEntity) {
        if(!this.EntityToDialogues.ContainsKey(baseEntity.InDialogueName)){
            Debug.Log("npc dialogue not found");
            return;
        }
        GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.isInDialogue = true;
        this.currentDialogueNPC = baseEntity;
        this.currentIndex = SaveLoader.getEntityDialogueIndex(this.currentDialogueNPC);
        SetObjectActive(true);
        this.ContinueDialogue();
    }
    private void ContinueDialogue(){
        Dialogue dialogue = this.EntityToDialogues[this.currentDialogueNPC.InDialogueName][currentIndex];
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
                EndDialogue(currentDialogueNPC, dialogue.NextDialogueIndex);
            };
        } else {
            this.ClickAction = () => {
                this.currentIndex = dialogue.NextDialogueIndex;
                this.ContinueDialogue();
            };
        }
    }
    private void EndDialogue(BaseNPC baseEntity, int index){
        this.ClickAction = null;
        SetObjectActive(false);
        GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.isInDialogue = false;
        SaveLoader.setEntityDialogueIndex(baseEntity, index); 
        int b = GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.isTur;
        if(b == 0){
            GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.moveTur();
            GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.isTur++;
        }else if(b == 1){
            GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.diaTur();
            GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.isTur++;
        }
    }

    private void SetObjectActive(bool b){
        dialogueBox.gameObject.SetActive(b);
        dialogueText.gameObject.SetActive(b);
        dialogueTalker.gameObject.SetActive(b);
        dialogueImage.gameObject.SetActive(b);
    }

}
