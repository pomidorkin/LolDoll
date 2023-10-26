using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketManager : MonoBehaviour
{
    private int ballPrice = 100;
    [SerializeField] BalanceManager balanceManager;
    [SerializeField] BallManager ballManager;
    [SerializeField] Button buyButton;
    [SerializeField] Button buyClickButton;
    [SerializeField] TMP_Text clickPriceText;

    public void BuyBall()
    {
        if (Progress.Instance.playerInfo.coins >= ballPrice)
        {
            Progress.Instance.playerInfo.coins -= ballPrice;
            Progress.Instance.playerInfo.dollBalls++;
            Progress.Instance.Save();
            balanceManager.UpdateBalanceText();
            ballManager.UpdateBallText();
            CheckBalance();
        }
    }

    public void ButClick()
    {
        if (Progress.Instance.playerInfo.coins >= (Progress.Instance.playerInfo.clickRevenue * 100))
        {
            Progress.Instance.playerInfo.coins -= (Progress.Instance.playerInfo.clickRevenue * 100);
            Progress.Instance.playerInfo.clickRevenue++;
            Progress.Instance.Save();
            balanceManager.UpdateBalanceText();
            CheckBalance();
        }
    }

    public void CheckBalance()
    {
        clickPriceText.text = (Progress.Instance.playerInfo.clickRevenue * 100).ToString();
        if (Progress.Instance.playerInfo.coins < ballPrice)
        {
            buyButton.interactable = false;
            
        } else
        {
            buyButton.interactable = true; ;
        }

        if (Progress.Instance.playerInfo.coins < (Progress.Instance.playerInfo.clickRevenue * 100))
        {
            buyClickButton.interactable = false;

        }
        else
        {
            buyClickButton.interactable = true; ;
        }
    }

}
