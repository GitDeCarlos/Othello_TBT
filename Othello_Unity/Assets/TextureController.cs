using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureController : MonoBehaviour
{
    public string TexturePack;
    private Sprite test = null;
    public Sprite test2;

    public GameObject board_bg;
    
    private void Start()
    {
        string FilePath = "TexturePacks/SimpleWood/bg.png";
        test = Resources.Load<Sprite>(FilePath);

        board_bg.GetComponent<Image>().sprite = test;
    }
}
