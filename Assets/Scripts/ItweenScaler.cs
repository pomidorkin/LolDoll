using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenScaler : MonoBehaviour
{
    private void OnEnable()
    {
        PlayScaleAnim();
    }
    public void PlayScaleAnim()
    {
        gameObject.transform.localScale = new Vector2(0, 0);
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "time", 0.6f, "easetype", iTween.EaseType.easeOutBack));
    }
}
