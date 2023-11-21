using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowFrequencyData {
    public string sampleText {get; set;}
    public Dictionary<string, int> dialogueSave {get; set;}
    public double LastStorySceneTime { get; set; }
    public int StorySceneRecordIndex { get; set; }
    public int StorySceneRecordTextIndex { get; set; }
    public int StorySceneAudioIndex = 0;
    public int StorySceneAudioIndexs { get; }
}
