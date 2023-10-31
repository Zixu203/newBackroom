using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class picture : MonoBehaviour
{
    public Image image;
    public void gif()
    {
        while(true)
        { 
            image.sprite = Resources.Load<Sprite>("face2");
            image.sprite = Resources.Load<Sprite>("face3");
            image.sprite = Resources.Load<Sprite>("face4");
            image.sprite = Resources.Load<Sprite>("face5");
            image.sprite = Resources.Load<Sprite>("face6");
            image.sprite = Resources.Load<Sprite>("face7");
            image.sprite = Resources.Load<Sprite>("face8");
            image.sprite = Resources.Load<Sprite>("face9");
            image.sprite = Resources.Load<Sprite>("face10");
        }
    }
    public void alert()
    {
        image.sprite = Resources.Load<Sprite>("alert");
    }
    public void angry()
    {
        image.sprite = Resources.Load<Sprite>("angry");
    }
    public void confuse()
    {
        image.sprite = Resources.Load<Sprite>("confuse");
    }
    public void normal()
    {
        image.sprite = Resources.Load<Sprite>("normal");
    }
    public void shock()
    {
        image.sprite = Resources.Load<Sprite>("shock");
    }
    public void smile()
    {
        image.sprite = Resources.Load<Sprite>("smile");
    }
    public void think()
    {
        image.sprite = Resources.Load<Sprite>("think");
    }
}
