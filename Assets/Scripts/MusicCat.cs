﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class MusicCat : MonoBehaviour {

    //Vector2 deltaVector = new Vector2(0f, 0f);
    Collider2D leftScrollArea;
    Text uiM;

    float spawnLocation;
    float size = 2.5f;

    SkeletonAnimation skeletonAnimation;

    Collider2D myTouchArea;

    Vector2 mousePos;

    static public List<MusicCat> cats = new List<MusicCat>();

    public int catNum;
    public AudioSource audioSource;

    public bool isDragging = false;

    private void Awake()
    {
        myTouchArea = GetComponent<Collider2D>();
    }
    private void OnDestroy()
    {
    }
    // Use this for initialization
    void Start() {
        uiM = GameObject.Find("Text").GetComponent<Text>();
        leftScrollArea = GameObject.Find("ScrollArea").GetComponent<Collider2D>();

        skeletonAnimation = transform.Find("Animation").GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (myTouchArea == Physics2D.OverlapPoint(mousePos))
            {
                cats.Remove(this);
                isDragging = true;

                PlayManager.instance.SetMusicCatNum(-1);

                foreach(var cat in MusicCat.cats)
                {
                    cat.catNum -= 1;
                    cat.ExcuteMove();
                }
            }
        }

        if (isDragging)
        {
            if (Input.GetMouseButtonUp(0))
            {
                MusicManager.Instance.playMusic = true;
                cats.Add(this);

                PlayManager.instance.SetMusicCatNum(1);
                catNum = PlayManager.instance.MusicCatNum;

                isDragging = false;

                StartCoroutine(MoveCat());

            }
            if (Input.GetMouseButton(0))
            {
                transform.position = mousePos;
            }
        }


        /*
        //uiM.text = transform.position.ToString() + " " + (PlayManager.instance.musicCatNum * PlayManager.instance.size);
        if (Input.touchCount > 0)
        {
            //uiM.text = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).ToString();

            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:

        if (myTouchArea == Physics2D.OverlapPoint(touchPos))
                    {
                        if (cats.Equals(this))
                        {
                            cats.Remove(this);
                        }
                        isDragging = true;
                    }

                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        transform.position = touchPos;
                    }

                    break;

                case TouchPhase.Ended:
                    if (isDragging)
                    {
                        if (Physics2D.OverlapPoint(touchPos) == leftScrollArea)
                        {
                            int num_Temp = PlayManager.instance.musicCatNum;
                            num_Temp -= 1;
                            PlayManager.instance.musicCatNum = num_Temp;

                            Destroy(gameObject);

                        }
                        else
                        {
                            MusicManager.Instance.playMusic = true;
                            cats.Add(this);

                            transform.position = new Vector2(transform.position.x, -0.5f);

                            musicCatNum_Temp += 1;
                            PlayManager.instance.MusicCatNum = musicCatNum_Temp;
                            spawnLocation = -6.0f + (PlayManager.instance.MusicCatNum * size);

                            StartCoroutine(MoveCat());
                        }
                    }

                    break;
            }

        }
        */
    } 

    IEnumerator DragCat()
    {
        while(true)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            yield return null;
        }
    }

    public void ExcuteMove()
    {
        StartCoroutine(MoveCat());
    }

    IEnumerator MoveCat()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "down", false);

        transform.position = new Vector2(transform.position.x, -0.5f);
        spawnLocation = -6.0f + (catNum * size);

        if (spawnLocation >= transform.position.x)
        {
            transform.position = new Vector2(spawnLocation, -0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        //i am groot
        float speed = 0f;

        while (true)
        {
            if (spawnLocation >= transform.position.x)
            {
                break;
            }

            speed += Time.deltaTime;

            transform.position = new Vector2(transform.position.x - speed, -0.5f);

            yield return null;
        }

        transform.position = new Vector2(spawnLocation, -0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (collision == leftScrollArea)
            {
                Destroy(gameObject);
            }
        }
    }
}
