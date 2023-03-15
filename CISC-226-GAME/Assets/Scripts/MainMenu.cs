using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // load the biggermap scene
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadLevel1(){
        // load the biggermap scene
        SceneManager.LoadScene("BiggerMap");
    }

    // public void GoToLevelSelect(){
    //     SceneManager.LoadScene("LevelSelect");
    // }

    public void GoToSettingsMenu(){
        SceneManager.LoadScene("OptionsMenu");
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }
}
