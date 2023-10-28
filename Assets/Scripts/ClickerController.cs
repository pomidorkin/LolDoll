using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ClickerController : MonoBehaviour
{
    [SerializeField] MMFeedbacks myMMFeedback;
    [SerializeField] BalanceManager balanceManager;
    [SerializeField] GameObject coinPrefab;
    void OnMouseDown()
    {
        myMMFeedback.PlayFeedbacks();
        balanceManager.IncrementBalance();
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(coinPrefab, mousePos, Quaternion.identity);
    }
}
