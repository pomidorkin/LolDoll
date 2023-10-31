using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownText : MonoBehaviour
{
    [SerializeField] TMP_Text countDownText;
    [SerializeField] GameObject parent;
    private float countDown;
    int i = 1;

    private void OnEnable()
    {
        i = 1;
        countDownText.text = 3.ToString();
    }

    private void Update()
    {
        countDown += Time.deltaTime;
        if (countDown >= 1f && i < 3)
        {
            countDown = 0;
            i++;
            countDownText.text = (4-i).ToString();
            iTween.ScaleTo(gameObject, iTween.Hash("x", 2, "y", 2, "time", .2, "easetype", iTween.EaseType.easeInOutBack, "oncomplete", "goBackToOriginal"));
        }
        else if (countDown >= 1f && i >= 3)
        {
            i = 1;
            countDown = 0;
            parent.SetActive(false);
        }
    }

    private void goBackToOriginal()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "time", .2, "easetype", iTween.EaseType.easeOutQuart));
    }
}
