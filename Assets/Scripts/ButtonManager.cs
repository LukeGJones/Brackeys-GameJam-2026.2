using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{
    public static float musicVolume = 0.75f;
    public static float sfxVolume = 0.75f;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TextMeshProUGUI newgameContinue;
    public GameObject levelCompleteBars;
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject PauseMenu;

    public IEnumerator WaitPointFive(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
    //Loads the level of the enter name
    public void LoadLevel (string sceneName)
    {
        Time.timeScale = 1;
        for(int i = 0; i < 6; i++){
                Transform bar = levelCompleteBars.transform.GetChild(i);
                StartCoroutine(bar.GetComponent<LoadingBars>().LevelOverAnim(i));
            }
        StartCoroutine(WaitPointFive(sceneName));
    }

    public void LoadFurthestLevel ()
    {
        Time.timeScale = 1;
        for(int i = 0; i < 6; i++){
                Transform bar = levelCompleteBars.transform.GetChild(i);
                StartCoroutine(bar.GetComponent<LoadingBars>().LevelOverAnim(i));
            }
        StartCoroutine(WaitPointFive(Finish.furthestLevel.ToString()));
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    //Quits the game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    //Returns to the main menu
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    //Returns to the pause menu
    public void ReturnToPauseMenu()
    {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    //Opens the settings menu
    public void OpenSettingsMenu()
    {
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    //Returns to the game and unpauses
    public void ReturnToGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        Finish.furthestLevel = 1;
    }

    public void Mute()
    {
        
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            sfxSlider.value = sfxVolume;
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            sfxVolume = sfxSlider.value;
        }

        if(Finish.furthestLevel > 1 && SceneManager.GetActiveScene().name == "MainMenu")
        {
            newgameContinue.text = "Continue";
        }
        else if (Finish.furthestLevel <= 1 && SceneManager.GetActiveScene().name == "MainMenu")
        {
            newgameContinue.text = "New Game";
        }
    }
}
