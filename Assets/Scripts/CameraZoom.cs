using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraZoom : MonoBehaviour {

    public int musicCatNum_Camera;
    int musicCatNum_Temp;
    bool isZooming = false;

    private void Awake()
    {
    }
    // Update is called once per frame
    void Update () {

        //GameObject.Find("Text").GetComponent<Text>().text = musicCatNum_Camera.ToString();

        if (musicCatNum_Camera != musicCatNum_Temp && isZooming == false)
        {
            StartCoroutine(Zoom(musicCatNum_Temp));
            musicCatNum_Temp = musicCatNum_Camera;
        }

    }

    IEnumerator Zoom(int musicCatNum)
    {
        float timer = 0f;

        isZooming = true;

        if (musicCatNum_Camera > 4 || (musicCatNum_Camera == 4 && musicCatNum == 5))
        {
            while (true)
            {
                if (timer >= 0.5f)
                {
                    break;
                }

                Camera.main.orthographicSize = Mathf.Lerp(5 + (musicCatNum - 4), 5 + (musicCatNum_Camera - 4), 2f * timer);
                Camera.main.transform.position = new Vector3(Mathf.Lerp((musicCatNum - 4), (musicCatNum_Camera - 4), 2f * timer), 0f, -10f);

                timer += Time.deltaTime;
                yield return null;
            }
        }

        isZooming = false;
    }
}
