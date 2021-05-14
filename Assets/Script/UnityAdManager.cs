using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour, IUnityAdsListener { 

    public static UnityAdManager instance;
    string gameId = "3816465";
    bool testMode = false;
    string placement_video = "video";
    string placement_interstitial = "interstitial";
    string placement_banner = "banner";
    string placement_reward = "rewardedVideo";


    void Start () {
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);

        StartCoroutine(ShowBannerWhenInitialized());
    }

// Diplay Video Ad
    public void DisplayVideoAd(){
        Advertisement.Show(placement_video);
    }

// Interstitial Ad
     public void ShowInterstitialAd() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady()) {
            Advertisement.Show(placement_interstitial);
        } 
        else {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

// Banner Ad
    IEnumerator ShowBannerWhenInitialized () {
        while (!Advertisement.isInitialized) {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show (placement_banner);
        Advertisement.Banner.SetPosition (BannerPosition.TOP_LEFT);
    }

    public void HideBanner(){
        Advertisement.Banner.Hide();
    }
    public void ShowRewardedVideo() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(placement_reward)) {
            Advertisement.Show(placement_reward);
        } 
        else {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }


     public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            Debug.Log("you got reward");
            Timer.instance.GameOverPanel.SetActive(false);
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == placement_reward) {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }
}