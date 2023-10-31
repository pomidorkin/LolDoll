using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", -.7f, "y", .7f, "time", 0.7f, "islocal", true, "easetype", iTween.EaseType.easeOutCirc));
        iTween.MoveTo(gameObject, iTween.Hash("x", -2.6f, "y", 5.15f, "time", 0.7f, "islocal", true, "easetype", iTween.EaseType.easeInCirc, "oncomplete", "ActionAfterTweenComplete"));
    }
    void ActionAfterTweenComplete()
    {
        Destroy(gameObject);
    }
}