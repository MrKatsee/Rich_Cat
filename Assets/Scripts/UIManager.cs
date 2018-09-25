using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject[] cats;
    public Text debug;

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
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        debug.text = "Hello!";

        cats_Temp = Instantiate(cats[buttonNum], touchPos, Quaternion.identity);
        //Input.GetTouch(0).position
    }
}
