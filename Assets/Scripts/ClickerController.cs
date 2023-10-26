using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ClickerController : MonoBehaviour
{
    [SerializeField] MMFeedbacks myMMFeedback;
    [SerializeField] BalanceManager balanceManager;
    void OnMouseDown()
    {
        myMMFeedback.PlayFeedbacks();
        balanceManager.IncrementBalance();
    }
}
