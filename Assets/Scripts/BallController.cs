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
    [SerializeField] DollDatasHolder dollDatasHolder;
    private List<DollDataScriptableObject> dollDatas;
    [SerializeField] SpriteRenderer dollSpriteRenderer;
    [SerializeField] BallManager ballManager;
    [SerializeField] ParticleSystem particleEffect;
    private Vector2 initialPosition;
    private Vector2 initialScale;
    bool opened = false;
    bool canBeClaimed = false;

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
        initialScale = transform.localScale;
        MoveBallToCenter();
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "time", .5f, "islocal", true, "easetype", iTween.EaseType.easeOutBack));
        dollDatas = dollDatasHolder.GetDollDatas();
    }

    private void MoveBallToCenter()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", 0, "y", 0, "time", .3, "islocal", true, "easetype", iTween.EaseType.easeOutBack));
    }

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
                StartCoroutine(ClaimDoll());
            }
        }
        else if(opened && canBeClaimed)
        {
            canBeClaimed = false;
            if (Progress.Instance.playerInfo.dollBalls > 0)
            {
                ResetBall();
            }
            else
            {
                RessetAndClose();
                //gameObject.SetActive(false);
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
        dollSpriteRenderer.gameObject.transform.parent.gameObject.SetActive(true);
        int i = Random.RandomRange(0, dollDatas.Count);
        dollSpriteRenderer.sprite = dollDatas[i].dollImage;
        float ratio = 500f / dollSpriteRenderer.sprite.texture.height;
        dollSpriteRenderer.gameObject.transform.localScale = new Vector2(1f * ratio, 1f * ratio);
        particleEffect.gameObject.SetActive(true);

        bool dollExists = false;

        if (Progress.Instance.playerInfo.collectedDollsDic.keys.Count > 0)
        {
            foreach (int item in Progress.Instance.playerInfo.collectedDollsDic.keys)
            {
                if (item == i)
                {
                    Progress.Instance.playerInfo.collectedDollsDic.IncrementValue(i, 1);
                    Progress.Instance.Save();
                    dollExists = true;
                    break;
                }
            }
        }

        if (!dollExists)
        {
            // TODO: Do somth when the doll is already in collection
            if (Progress.Instance.playerInfo.collectedDollsDic == null)
            {
                Progress.Instance.playerInfo.collectedDollsDic = new IntIntDictionary();
            }
            Progress.Instance.playerInfo.collectedDollsDic.Add(i, 1);
            Progress.Instance.Save();

        }
        Progress.Instance.playerInfo.dollBalls--;
        ballManager.UpdateBallText();
        Progress.Instance.Save();
    }

    private IEnumerator ClaimDoll()
    {
        yield return new WaitForSeconds(0.3f);
        canBeClaimed = true;
    }

    private void ResetBall()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", 5, "time", .3, "oncomplete", "ActionAfterTweenComplete", "oncompletetarget", gameObject, "easetype", iTween.EaseType.easeInQuint));
    }


    public void ResetMethod()
    {
        animator.Play("idle");
        opened = false;
        clicks = 0;
        dollSpriteRenderer.gameObject.transform.parent.gameObject.SetActive(false);
        particleEffect.Stop();
        particleEffect.gameObject.SetActive(false);
    }

    public void RessetAndClose()
    {
        animator.Play("customIdle");
    }

    public void AnimResetter()
    {
        opened = false;
        clicks = 0;
        dollSpriteRenderer.gameObject.transform.parent.gameObject.SetActive(false);
        particleEffect.Stop();
        transform.localPosition = initialPosition;
        transform.localScale = initialScale;
        particleEffect.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void ActionAfterTweenComplete()
    {
        MoveBallToCenter();
        ResetMethod();
        transform.position = new Vector2(-5, 0);
    }
}
