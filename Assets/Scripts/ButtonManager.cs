using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public Sprite[] buttonOnOff = new Sprite[2];
    public bool isButtonOn = true;
    public GameObject cat;

    public static List<ButtonManager> buttons = new List<ButtonManager>();

    public bool IsButtonOn
    {
        get
        {
            return isButtonOn;
        }
        set
        {
            isButtonOn = value;
            SwitchSprite();
        }
    }
    Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttons.Add(this);
    }

    public void RemoveButtonList()
    {
        buttons.Remove(this);
    }

    void SwitchSprite()
    {
        if (isButtonOn)
        {
            buttonImage.sprite = buttonOnOff[0];
        }
        else
        {
            buttonImage.sprite = buttonOnOff[1];
        }
    }
}
