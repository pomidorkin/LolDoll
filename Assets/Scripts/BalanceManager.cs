using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    [SerializeField] TMP_Text balanceText;
    private float nextTimeCall = 0f;
    [SerializeField] float saveInterval = 10f;
    private int lastChackedBalance = 0;

    private void Start()
    {
        UpdateBalanceText();
    }

    public void IncrementBalance()
    {
        Progress.Instance.playerInfo.coins += Progress.Instance.playerInfo.clickRevenue;
        UpdateBalanceText();
    }

    public void UpdateBalanceText()
    {
        balanceText.text = Progress.Instance.playerInfo.coins.ToString();
    }

    void Update()
    {
        nextTimeCall += Time.deltaTime;
        if (nextTimeCall >= saveInterval && (lastChackedBalance != Progress.Instance.playerInfo.coins))
        {
            nextTimeCall = 0;
            lastChackedBalance = Progress.Instance.playerInfo.coins;
            Progress.Instance.Save();
            Debug.Log("Сохранение сработало");
        }
    }
}
