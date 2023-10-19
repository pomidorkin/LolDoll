using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class BallController : MonoBehaviour
{
    [SerializeField] MMFeedbacks myMMFeedback;
    [SerializeField] Animator animator;
    private int clicks = 0;
    [SerializeField] int clickLimit = 10;
    [SerializeField] List<DollDataScriptableObject> dollDatas;
    [SerializeField] SpriteRenderer dollSpriteRenderer;
    bool opened = false;
    void OnMouseDown()
    {
        if (!opened)
        {
            myMMFeedback.PlayFeedbacks();
            clicks++;
            if (clicks >= clickLimit)
            {
                OpenBall();
                opened = true;
                SpawnDoll();
            }
        }
    }

    public void OpenBall()
    {
        animator.Play("BallOpenAnimation");
    }

    private void SpawnDoll()
    {
        // TODO: Safe dolls here
        dollSpriteRenderer.gameObject.SetActive(true);
        int i = Random.RandomRange(0, dollDatas.Count);
        dollSpriteRenderer.sprite = dollDatas[i].dollImage;
    }
}
