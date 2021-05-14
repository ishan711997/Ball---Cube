using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    
    public void GoToNextLevel(){
        int CurrentLevel = PlayerPrefs.GetInt("ReachLevel", 1);

        // for save game 
        PlayerPrefs.SetInt("ReachLevel", CurrentLevel + 1);

        // after compliting a lvl go to next lvl
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // When go to next level next level time will be normally, if this is not set then time will paused
        Time.timeScale = 1;
    }

    public void RestartLvl(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
