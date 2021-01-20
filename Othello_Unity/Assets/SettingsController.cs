using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private bool _startingGameStatus = true; //starting game status, t = 1p, f = 2p
    private string _currentTexture = "SimpleWood";
    private int _musicLevel;
    private int _soundLevel;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void SetCurrentTexture()
    {
        //TMP_Dropdown dropDown = GameObject.Find("TextureDropDown").GetComponent<TMP_Dropdown>();
        //_currentTexture = dropDown.options[dropDown.value].text;
        
    }
    
    public string GetCurrentTexture()
    {
        return _currentTexture;
    }
}
