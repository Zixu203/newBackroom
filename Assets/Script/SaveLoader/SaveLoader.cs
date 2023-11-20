using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoader {
    private static string baseDir = Application.persistentDataPath + "/";
    private static HighFrequencyData highFrequencyData;
    private static LowFrequencyData lowFrequencyData;
    public static void SaveAll() {
        if(!File.Exists(SaveLoader.baseDir + "HighFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "HighFrequencyData.txt").Close();
        }
        if(!File.Exists(SaveLoader.baseDir + "LowFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "LowFrequencyData.txt").Close();
        }
        File.WriteAllText(SaveLoader.baseDir + "HighFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.highFrequencyData));
        File.WriteAllText(SaveLoader.baseDir + "LowFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.lowFrequencyData));
    }
    public static void SaveHigh() {
        if(!File.Exists(SaveLoader.baseDir + "HighFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "HighFrequencyData.txt").Close();
        }
        File.WriteAllText(SaveLoader.baseDir + "HighFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.highFrequencyData));
    }
    public static void SaveLow() {
        if(!File.Exists(SaveLoader.baseDir + "LowFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "LowFrequencyData.txt").Close();
        }
        File.WriteAllText(SaveLoader.baseDir + "LowFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.lowFrequencyData));
    }

    public static void Load() {
        if(File.Exists(SaveLoader.baseDir + "HighFrequencyData.txt")){
            SaveLoader.highFrequencyData = JsonConvert.DeserializeObject<HighFrequencyData>(File.ReadAllText(SaveLoader.baseDir + "HighFrequencyData.txt"));
            if(SaveLoader.highFrequencyData == null) SaveLoader.highFrequencyData = new HighFrequencyData();
        }else{
            SaveLoader.highFrequencyData = new HighFrequencyData();
            Debug.Log("high give new");
        }

        if(File.Exists(SaveLoader.baseDir + "LowFrequencyData.txt")){
            SaveLoader.lowFrequencyData = JsonConvert.DeserializeObject<LowFrequencyData>(File.ReadAllText(SaveLoader.baseDir + "LowFrequencyData.txt"));
            if(SaveLoader.lowFrequencyData == null) SaveLoader.lowFrequencyData = new LowFrequencyData();
        }else{
            SaveLoader.lowFrequencyData = new LowFrequencyData() {
                dialogueSave = new Dictionary<string, int>()
            };
            Debug.Log("low give new");
        }
    }


    public static string getSceneName(){
        return SaveLoader.lowFrequencyData.sampleText;
    }

    public static void setSceneName(string sampleText){
        SaveLoader.lowFrequencyData.sampleText = sampleText;
        SaveLoader.SaveLow();
    }

    public static int getEntityDialogueIndex(BaseEntity baseEntity) {
        if(SaveLoader.lowFrequencyData.dialogueSave.ContainsKey(baseEntity.gameObject.name) == false){
            setEntityDialogueIndex(baseEntity, 0);
        }
        return SaveLoader.lowFrequencyData.dialogueSave[baseEntity.gameObject.name];
    }

    public static void setEntityDialogueIndex(BaseEntity baseEntity, int index) {
        SaveLoader.lowFrequencyData.dialogueSave[baseEntity.gameObject.name] = index;
        SaveLoader.SaveLow();
    }

    public static double getLastStorySceneTime(){
        return SaveLoader.lowFrequencyData.LastStorySceneTime;
    }
    public static void setLastStorySceneTime(double lastStorySceneTime)
    {
        SaveLoader.lowFrequencyData.LastStorySceneTime = lastStorySceneTime;
        SaveLoader.lowFrequencyData.StorySceneRecordIndex++;
        SaveLoader.SaveLow();
    }
    public static void setStorySceneRecordIndex(int StorySceneRecordIndex)
    {
        SaveLoader.lowFrequencyData.StorySceneRecordIndex=StorySceneRecordIndex;
        SaveLoader.SaveLow();
    }
    public static int getStorySceneRecordIndex()
    {
        return SaveLoader.lowFrequencyData.StorySceneRecordIndex;
    }
    public static void setStorySceneRecordTextIndex(int StorySceneRecordTextIndex)
    {
        SaveLoader.lowFrequencyData.StorySceneRecordTextIndex = StorySceneRecordTextIndex;
        SaveLoader.SaveLow();
    }
    public static int getStorySceneRecordTextIndex()
    {
        return SaveLoader.lowFrequencyData.StorySceneRecordTextIndex;
    }
}
