using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject[] cats;
    public Image[] catButton;
    public Text debug;

    public int test = 0;

	// Use this for initialization
	void Start () {
        debug = transform.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("mouse posi: " + Camera.main.ScreenToWorldPoint (Input.mousePosition));
    }

    public void CatClick(int buttonNum)
    {
        GameObject cats_Temp;
        // Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        ButtonManager buttonManager = catButton[buttonNum].GetComponent<ButtonManager>();

        if (buttonManager.isButtonOn)
        {

            cats_Temp = Instantiate(cats[buttonNum], mousePos, Quaternion.identity);
            buttonManager.IsButtonOn = false;
            cats_Temp.GetComponent<MusicCat>().isDragging = true;
        }

        //debug.text = "Hello!";

        //Input.GetTouch(0).position
    }


    public void TestClicke()
    {
        test++;

        Camera.main.orthographicSize = 5 + test;
        Camera.main.transform.position = new Vector3(test, 0, -10);
    }
}
