using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneFader : MonoBehaviour
{
    public Image img;

    void Start(){
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn(){
        float t = 1f;

        while(t > 0f){
            t -=Time.deltaTime;
            //t is alpha value and color(0,0,0) is rgb color
            img.color = new Color(0f, 0f, 0f, t);  
            yield return 0;
        }

        //Load a scene
    }
}
