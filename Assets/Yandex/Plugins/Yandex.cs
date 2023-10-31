using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Plugins.Audio.Core;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void CheckCanReview();

    [DllImport("__Internal")]
    private static extern void AddCoinsExtern();

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [SerializeField] GameObject rateGameButton;
    [SerializeField] BallManager ballManager;
    [SerializeField] GameObject rewardedAdButton;

    // Rewarded
    private bool rewardedButtonActivated = false;
    private float timeCounter = 0;
    [SerializeField] float rewardedAdShowFrequency = 90f;

    //Inter
    private float interAdCounter = 0;
    [SerializeField] private float interAdShowFrequency = 240f;
    [SerializeField] GameObject countDownTextParent;


    private void Start()
    {
        CheckCanReview();
        AudioPauseHandler.Instance.PauseAudio();
        AudioPauseHandler.Instance.UnpauseAudio();
    }

    private void Update()
    {
        if (timeCounter >= rewardedAdShowFrequency && !rewardedButtonActivated)
        {
            rewardedButtonActivated = true;
            rewardedAdButton.SetActive(true);
            timeCounter = 0;
        }
        else if (!rewardedButtonActivated)
        {
            timeCounter += Time.deltaTime;
        }

        // Inter Ad
        if (interAdCounter < interAdShowFrequency)
        {
            interAdCounter += Time.deltaTime;
        }
        else
        {
            interAdCounter = 0;
            ShowInterAd();
        }
    }

    public void UnpauseAudio()
    {
        AudioPauseHandler.Instance.UnpauseAudio();
    }

    private IEnumerator ShowInterAdCoroutine()
    {
        countDownTextParent.SetActive(true);
        yield return new WaitForSeconds(3);
        countDownTextParent.SetActive(false);
        rewardedButtonActivated = false;
        AudioPauseHandler.Instance.PauseAudio();
        ShowAdv();

    }

    public void RateGameBurtton()
    {
        RateGame();
    }

    private void ShowInterAd()
    {
        StartCoroutine(ShowInterAdCoroutine());
    }

    public void EnableRateGameButton()
    {
        rateGameButton.SetActive(true);
    }

    public void DisableRateGameButton()
    {
        rateGameButton.SetActive(false);
    }

    public void RewardPlayer()
    {
        Progress.Instance.playerInfo.dollBalls += 10;
        Progress.Instance.Save();
        AudioPauseHandler.Instance.UnpauseAudio();
        ballManager.UpdateBallText();
    }

    public void ShowRewardedAd()
    {
        rewardedAdButton.SetActive(false);
        AudioPauseHandler.Instance.PauseAudio();
        AddCoinsExtern();
    }
}
