using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {

    public static PlayManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int musicCatNum = 0;
    public float size = 2.5f;
}
