using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour {

    public static PlayManager instance;

    CameraZoom cameraZoom;

    public PlayManager() : base()
    {
        instance = this;
    }

    private void Awake()
    {
        cameraZoom = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
    }


    public int musicCatNum = 0;

    public int MusicCatNum
    {
        get
        {
            return musicCatNum;
        }

        set
        {
            musicCatNum = value;

            cameraZoom.musicCatNum_Camera = musicCatNum;

            if (musicCatNum == 0)
            {
                MusicManager.Instance.PlayMusic = false;
            }
        }
    }

    public void SetMusicCatNum(int value)
    {
        int tempNum;

        if (value ==  1)
        {
            tempNum = MusicCatNum;
            tempNum++;
            MusicCatNum = tempNum;
        }
        else if (value == -1)
        {
            tempNum = MusicCatNum;
            tempNum--;
            MusicCatNum = tempNum;
        }
    }

}
