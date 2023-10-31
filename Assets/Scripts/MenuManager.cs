using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Utils;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject scrollSnap;
    [SerializeField] BallManager ballManager;
    [SerializeField] BallController ballController;
    [SerializeField] GameObject clickerDollImage;
    [SerializeField] GameObject marketPopup;
    [SerializeField] MarketManager marketManager;
    [SerializeField] VulomeManager volumeManager;
    // SFX
    [SerializeField] AudioDataProperty clip;

    public int selectedDollId;

    public void CloseAllMenus()
    {
        SoundManager.Instance.PlaySound(clip);
        ballController.RessetAndClose();
        scrollSnap.SetActive(false);
        clickerDollImage.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();
    }

    public void OpenScrollSnap()
    {
        SoundManager.Instance.PlaySound(clip);
        ballController.RessetAndClose();
        clickerDollImage.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();

        scrollSnap.SetActive(true);
    }

    public void OpenBallOpenMenu()
    {
        SoundManager.Instance.PlaySound(clip);
        scrollSnap.SetActive(false);
        clickerDollImage.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();

        ballManager.ActivateBall();
    }

    public void OpenClickerDollImage()
    {
        SoundManager.Instance.PlaySound(clip);
        //ballController.RessetAndClose();
        scrollSnap.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();

        clickerDollImage.SetActive(true);
    }

    public void OpenMarketPopup()
    {
        SoundManager.Instance.PlaySound(clip);
        ballController.RessetAndClose();
        scrollSnap.SetActive(false);
        clickerDollImage.SetActive(false);
        volumeManager.CloseVolumePopup();

        marketPopup.SetActive(true);
        marketManager.CheckBalance();
    }
}
