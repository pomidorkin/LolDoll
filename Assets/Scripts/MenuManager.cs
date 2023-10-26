using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject scrollSnap;
    [SerializeField] BallManager ballManager;
    [SerializeField] BallController ballController;
    [SerializeField] GameObject clickerDollImage;
    [SerializeField] GameObject marketPopup;
    [SerializeField] MarketManager marketManager;
    [SerializeField] VulomeManager volumeManager;

    public int selectedDollId;

    public void CloseAllMenus()
    {
        ballController.RessetAndClose();
        scrollSnap.SetActive(false);
        clickerDollImage.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();
    }

    public void OpenScrollSnap()
    {
        ballController.RessetAndClose();
        clickerDollImage.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();

        scrollSnap.SetActive(true);
    }

    public void OpenBallOpenMenu()
    {
        scrollSnap.SetActive(false);
        clickerDollImage.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();

        ballManager.ActivateBall();
    }

    public void OpenClickerDollImage()
    {
        //ballController.RessetAndClose();
        scrollSnap.SetActive(false);
        marketPopup.SetActive(false);
        volumeManager.CloseVolumePopup();

        clickerDollImage.SetActive(true);
    }

    public void OpenMarketPopup()
    {
        ballController.RessetAndClose();
        scrollSnap.SetActive(false);
        clickerDollImage.SetActive(false);
        volumeManager.CloseVolumePopup();

        marketPopup.SetActive(true);
        marketManager.CheckBalance();
    }
}
