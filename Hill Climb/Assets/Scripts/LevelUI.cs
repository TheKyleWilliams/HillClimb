using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentLevel = GetCurrentLevel();
        levelText.text = "Level " + currentLevel;
    }

    int GetCurrentLevel() {
        return PlayerPrefs.GetInt("CurrentLevel", 1);
    }
}
