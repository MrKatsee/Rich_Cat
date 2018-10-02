using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour {

    public SpriteRenderer target;

    public List<Sprite> sprites;
    public int selectSprite;
    
    int currentSpriteNum = -1;

    
	
	// Update is called once per frame
	void Update () {
        if (currentSpriteNum != selectSprite)
        {
            currentSpriteNum = selectSprite;
            target.sprite = sprites[currentSpriteNum];
        }
	}
}
