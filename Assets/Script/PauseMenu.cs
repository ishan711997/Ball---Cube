using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuUI;

    public void PuaseControl(){
        if(Time.timeScale == 1){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
        }
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }

    // go to main menu 
    public void LoadMainMenu(){
        SceneManager.LoadScene("Menu");
    }
}
