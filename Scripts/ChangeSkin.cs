using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Sprite[] skins;
    public int characterSkin;

    // Start is called before the first frame update
    void Start()
    {
        characterSkin = PlayerPrefs.GetInt("CharacterSprite");
        GetComponent<SpriteRenderer>().sprite = skins[characterSkin];
    }
}
