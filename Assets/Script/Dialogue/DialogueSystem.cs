using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue {
    public bool isEnd;
    public List<string> strings;
    public List<Dialogue> nextDialogue = new List<Dialogue>() {
        //index 0
        //index 1
    };
    public Dialogue(List<string> strings){
        this.strings = strings;
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

public class DialogueSystem {
    Dictionary<BaseEntity, List<Dialogue>> keyValuePairs;
    public DialogueSystem() {
        keyValuePairs = new Dictionary<BaseEntity, List<Dialogue>>(){
            [GameController.getInstance.npcs[0]] = new List<Dialogue>() {
                new Dialogue(new List<string>() {
                    "幫我裝水",
                    "拜託拉"
                }){
                    nextDialogue = new List<Dialogue>() {
                        //1 yes
                        //2 no
                    }
                },
                new Dialogue(new List<string>(){
                    "謝拉啊啊啊啊"
                }) {
                    nextDialogue = new List<Dialogue>(){
                        //3
                    }
                },
                new Dialogue(new List<string>(){
                    "為什麼不要 嗚嗚"
                }) {
                    nextDialogue = new List<Dialogue>(){
                        //0
                    }
                },
                new Dialogue(new List<string>() {
                    "你拿回來了喔",
                    "哈哈 但是我想喝飲料"
                })
            },


            [GameController.getInstance.npcs[1]] = new List<Dialogue>() {

            }
        };
    }

    public Text outSideUI;

    public void StartDialogue(BaseEntity baseEntity) {
        //index: 
        int index = SaveLoader.getEntityDialogueIndex(baseEntity);
        Dialogue dialogue = this.keyValuePairs[baseEntity][index];
        //ui set active true
        this.ContinueDialogue(dialogue, index);
    }
    private void ContinueDialogue(Dialogue dialogueNode, int index){
        //setup text
        //setup action text
        //setup action button event <- put continue dialogue in button event
        //or
        //setup action button event <- put end dialogue in button event
    }
    private void EndDialogue(Dialogue dialogueNode, int index){
        //ui set active false
        // SaveLoader.setEntityDialogueIndex(dialogueNode.baseEntity, index);
    }
}
