using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTime : MonoBehaviour
{
    
public float extraTime = 10f;
public Text textBox;
public GameObject GameOverPanel;

    void Update()
    {
        Time.timeScale = 1;
        Debug.Log("Update called");
        extraTime -= Time.deltaTime;
        textBox.text = extraTime.ToString("0");
        if (extraTime <= 0)
        {
            extraTime = 0;
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            // for false interactable child game object button
            GameOverPanel.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false; 
        }
        if(GameObject.FindWithTag("Pick up") == null){
            //for stoping game
            Time.timeScale = 0;
        }
    }
}
