using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scenes : MonoBehaviour
{
    public Image image;
    public void scene()
    {
        while (true)
        {
            image.sprite = Resources.Load<Sprite>("war1");
            image.sprite = Resources.Load<Sprite>("war2");
            image.sprite = Resources.Load<Sprite>("war3");
            image.sprite = Resources.Load<Sprite>("war4");
            image.sprite = Resources.Load<Sprite>("war5");
            image.sprite = Resources.Load<Sprite>("war6");
            image.sprite = Resources.Load<Sprite>("war7");
            image.sprite = Resources.Load<Sprite>("war8");
            image.sprite = Resources.Load<Sprite>("war9");
            image.sprite = Resources.Load<Sprite>("war10");
            image.sprite = Resources.Load<Sprite>("war11");
            image.sprite = Resources.Load<Sprite>("war12");
        }
    }
}
