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
            File.Create(SaveLoader.baseDir + "HighFrequencyData.txt");
        }
        if(!File.Exists(SaveLoader.baseDir + "LowFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "LowFrequencyData.txt");
        }
        File.WriteAllText(SaveLoader.baseDir + "HighFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.highFrequencyData));
        File.WriteAllText(SaveLoader.baseDir + "LowFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.lowFrequencyData));
    }
    public static void SaveHigh() {
        if(!File.Exists(SaveLoader.baseDir + "HighFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "HighFrequencyData.txt");
        }
        File.WriteAllText(SaveLoader.baseDir + "HighFrequencyData.txt", JsonConvert.SerializeObject(SaveLoader.highFrequencyData));
    }
    public static void SaveLow() {
        if(!File.Exists(SaveLoader.baseDir + "LowFrequencyData.txt")){
            File.Create(SaveLoader.baseDir + "LowFrequencyData.txt");
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
            SaveLoader.lowFrequencyData = new LowFrequencyData();
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
}
