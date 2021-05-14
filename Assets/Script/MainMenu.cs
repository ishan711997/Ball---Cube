using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  
    //Screen Resolution
    // Resolution[] resolutions;   //we take a array variable

    // public Dropdown resolutionDropdown; //take a dropdown reference
    // void Start(){
    //     resolutions = Screen.resolutions;
    //     resolutionDropdown.ClearOptions(); // clear option when start 

    //     List<string> options = new List<string>();

    //     for(int i=0; i<resolutions.Length; i++){
    //         string option = resolutions[i].width + " x " + resolutions[i].height;
    //         options.Add(option);
    //     }

    //     resolutionDropdown.AddOptions(options);
    // }

    //Play Game
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1; //we declare here scale time therefore game will run on normal time
    }

    //Quit Game
    public void QuitGame(){
        Debug.Log("quit");
        Application.Quit();
    }
    
    //Volume Setting
    public AudioMixer audiomixer;
    public void SetVolume(float volume){
        audiomixer.SetFloat("Volume", volume);  //first parameter into the "" should be same as in unity audiomixer    
    }

    //Graphics Setting
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Full Screen
    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    
    // Load Level
    public void loadLevel(){
        SceneManager.LoadScene("Level Select");
    }
}
