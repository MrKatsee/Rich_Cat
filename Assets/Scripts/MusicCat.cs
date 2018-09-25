using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCat : MonoBehaviour {
    
    //Vector2 deltaVector = new Vector2(0f, 0f);
    Collider2D leftScrollArea;
    Text uiM;
    float spawnLocation;

    bool isDragging = true;

	// Use this for initialization
	void Start () {
        uiM = GameObject.Find("Text").GetComponent<Text>();
        leftScrollArea = GameObject.Find("Scroll View").GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        uiM.text = transform.position.ToString() + " " + (PlayManager.instance.musicCatNum * PlayManager.instance.size);
        if (Input.touchCount > 0 && isDragging)
        {
            //uiM.text = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).ToString();

            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    /*
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaVector.x = touchPos.x - transform.position.x;
                        deltaVector.y = touchPos.y - transform.position.y;
                    }
                    */
                    break;

                case TouchPhase.Moved:

                    transform.position = touchPos;
                    /*
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                    }
                    */
                    //uiM.text = transform.position.ToString();
                    break;
                case TouchPhase.Ended:
                    if (Physics2D.OverlapPoint(touchPos) == leftScrollArea)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        isDragging = false;
                        transform.position = new Vector2(transform.position.x, -0.5f);
                        PlayManager.instance.musicCatNum += 1;
                        spawnLocation = -6.0f + (PlayManager.instance.musicCatNum * PlayManager.instance.size);

                        StartCoroutine(moveCat());
                    }
                    break;
            }
        }
	}

    IEnumerator moveCat()
    {
        yield return new WaitForSeconds(0.5f);

        float speed = 0f;

        while (spawnLocation >= transform.position.x)
        {
            speed += Time.deltaTime;

            transform.position = new Vector2(transform.position.x - speed, -0.5f);

            yield return null;
        }

        transform.position = new Vector2(spawnLocation, -0.5f);
    }
}
