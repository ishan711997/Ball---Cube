using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float timeStart = 0f;
    public Text textBox;
    public GameObject GameOverPanel;
    public bool activeControl;

    void Start() {
        textBox.text = timeStart.ToString();    
        // GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update() {
        timeStart -= Time.deltaTime;
        textBox.text = timeStart.ToString("0"); // or can use Mathf.Round(timeStart).ToString()
   
        // this code will set 0 when time go to -ve
        if(timeStart <= 0){
            timeStart = 0;

            GameOver();
        }
    }

    void GameOver(){
        // you can use without if else 
        if(activeControl == false){
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }else{
            Time.timeScale = 1;
            GameOverPanel.SetActive(false);
        }
    }
}
