using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextureController : MonoBehaviour
{
    public string TexturePack;
    public GameObject board_bg;

    private String FilePath;
    
    private void Awake()
    {
        GameObject settingsController = GameObject.Find("SettingsController");
        SettingsController settings = settingsController.GetComponent<SettingsController>();
        
        TexturePack = settings.GetCurrentTexture();
        
        FilePath = "Assets/TexturePacks/" + TexturePack;

        board_bg.GetComponent<Image>().sprite = LoadNewSprite(FilePath + "/bg.png");
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

    public String getFilePath()
    {
        Debug.Log(FilePath);
        return FilePath;
    }
}
