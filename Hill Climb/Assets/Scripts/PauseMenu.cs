using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject settingsPanelUI;
    public GameObject tutorialPanelUI;
    public static bool gameIsPaused = false;

    public int currentLevel;
    void Start() 
    {
        // load level
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }

        currentLevel = PlayerPrefs.GetInt("CurrentLevel");

        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        Debug.Log("Current Level in PauseMenu: " + currentLevel);

        // if on level 1, automatically open tutorial
        if (currentLevel == 1)
        {
            Pause();
            OpenTutorial();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }

    }

    public void Resume()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        settingsPanelUI.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenuUI.SetActive(true);
        settingsPanelUI.SetActive(false);
    }

    // Method to open the tutorial panel
    public void OpenTutorial()
    {
        mainMenuUI.SetActive(false);
        tutorialPanelUI.SetActive(true);
    }

    // Method to close the tutorial panel
    public void CloseTutorial()
    {
        tutorialPanelUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}