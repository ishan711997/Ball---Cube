using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Button[] LevelButtons;
//for reset all buttons 
// private void Start() {

//     PlayerPrefs.DeleteAll();
// }

    private void Awake() {
        //this is awake fn so play and see in the debug in unity

        int ReachLevel = PlayerPrefs.GetInt("ReachLevel", 1);

        // for count Button means how much button is there 
        LevelButtons = new Button[transform.childCount];

        // for automatically adding those button into the slot
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();

            // for automatically numbering on buttons
            LevelButtons[i].GetComponentInChildren<Text>().text = (i+1).ToString(); 
            //GetComponentInChildren means component in child element means grandchildren

            if(i + 1 > ReachLevel){
                // it will false all button interactable
                LevelButtons[i].interactable = false;
            }
        }
    }

    public void PlayLevel(int Level){
        SceneManager.LoadScene(Level);
        Time.timeScale = 1;//we declare here scale time therefore game will run on normal time
    }
}
