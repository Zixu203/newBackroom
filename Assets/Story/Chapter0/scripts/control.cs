using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class control : MonoBehaviour
{
    public Image image;
    public void tr()
    {
        image.enabled=true;
    }
    public void fa()
    {
        image.enabled = false;
    }
}
