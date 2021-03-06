﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private SettingsController _settings;
    
    void Start()
    {
        // Get settings script for changes
        _settings = GameObject.Find("SettingsController").GetComponent<SettingsController>();
        
        // Get the dropdown component
        var dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        dropdown.options.Clear();
        
        // Fill dropdown with texturepack folder names
        string[] dir = Directory.GetDirectories("Assets/TexturePacks");
        for (int i = 0; i < dir.Length; i++)
        {
            Debug.Log(i + ": " + dir[i].Substring(20));
            dropdown.options.Add(new TMP_Dropdown.OptionData() {text = dir[i].Substring(20)});
        }

        dropdown.onValueChanged.AddListener(delegate { _settings.SetCurrentTexture(dropdown.options[dropdown.value].text); });
    }
}
