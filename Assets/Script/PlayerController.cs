using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public GameObject NextLevelPanel;
    public GameObject PauseBtn;
    public GameObject GameOverPanel;
    private Rigidbody rb;
    private int count;

    // AUDIO 
    public AudioClip Clip;
    AudioSource audioSource;
    // ********************

    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        NextLevelPanel.SetActive (false);

    // audio 
        audioSource = GetComponent<AudioSource>();
    // ********************
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);   //new Vector3 (x, y, z);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pick up")){
            // this is for removing object after colliding
            other.gameObject.SetActive(false);
            
            count = count + 1;
            SetCountText();
        }

        if(other.gameObject.CompareTag("BlackPickups")){
            GameOver();
        }
    }

    void SetCountText(){
        countText.text = count.ToString();
        if(GameObject.FindWithTag("Pick up") == null){

            // for next lvl panel load
            NextLevelPanel.SetActive (true);
            PauseBtn.SetActive(false);

            //for stoping game
            Time.timeScale = 0;

            // audio 
            audioSource.clip = Clip;
            audioSource.Play();
            audioSource.loop = false;
            // ********************
        }
    }
    void GameOver(){
        Time.timeScale = 0;
        // UnityAdManager.Instance.DisplayVideoAd();
        GameOverPanel.SetActive(true);
    }
}
