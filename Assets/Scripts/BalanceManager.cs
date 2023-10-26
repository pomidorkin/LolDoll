using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    [SerializeField] TMP_Text balanceText;

    private void Start()
    {
        UpdateBalanceText();
    }

    public void IncrementBalance()
    {
        Progress.Instance.playerInfo.coins += Progress.Instance.playerInfo.clickRevenue;
        Progress.Instance.Save();
        UpdateBalanceText();
    }

    public void UpdateBalanceText()
    {
        balanceText.text = Progress.Instance.playerInfo.coins.ToString();
    }
}
