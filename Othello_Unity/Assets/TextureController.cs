using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextureController : MonoBehaviour
{
    public string TexturePack;
    private Sprite test = null;
    public Sprite test2;

    public GameObject board_bg;
    
    private void Start()
    {
        GameObject settingsController = GameObject.Find("SettingsController");
        SettingsController settings = settingsController.GetComponent<SettingsController>();
        
        TexturePack = settings.GetCurrentTexture();
        
        string FilePath = "Assets/TexturePacks/" + TexturePack + "/bg.png";
        test = Resources.Load<Sprite>(FilePath);

        board_bg.GetComponent<Image>().sprite = LoadNewSprite(FilePath);
    }

    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {
        Texture2D SpriteTexture = LoadTexture(FilePath);
        Sprite newSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),
            new Vector2(0, 0), PixelsPerUnit, 0, spriteType);
        
        return newSprite;
    }

    public static Texture2D LoadTexture(string FilePath)
    {
        Texture2D text2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            text2D = new Texture2D(2, 2);
            if (text2D.LoadImage(FileData))
            {
                return text2D;
            }
        }
        return null;
    }
}
