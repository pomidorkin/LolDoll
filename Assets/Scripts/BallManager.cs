using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballDoll;
    [SerializeField] TMP_Text ballText;
    private void Start()
    {
        UpdateBallText();
    }
    public void ActivateBall()
    {
        if (Progress.Instance.playerInfo.dollBalls > 0)
        {
            ballDoll.SetActive(true);
        }
    }

    public void UpdateBallText()
    {
        ballText.text = Progress.Instance.playerInfo.dollBalls.ToString();
    }
}
