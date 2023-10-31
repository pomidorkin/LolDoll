using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialParent;
    [SerializeField] GameObject[] tutorialBlocks;
    [SerializeField] MenuManager menuManager;
    //[SerializeField] BallManager ballManager;
    int currentBlock = 0;

    private void Start()
    {
        if (!Progress.Instance.playerInfo.firstStart)
        {
            tutorialParent.SetActive(true);

            Progress.Instance.playerInfo.collectedDollsDic = new IntIntDictionary();
            Progress.Instance.Save();
            NextTutorial();
        }
    }

    public void NextTutorial()
    {
        foreach (GameObject item in tutorialBlocks)
        {
            item.SetActive(false);
        }
        if (currentBlock >= 3)
        {
            tutorialParent.SetActive(false);
            Progress.Instance.playerInfo.firstStart = true;
            //Progress.Instance.playerInfo.dollBalls += 10;
            //ballManager.UpdateBallText();

            Progress.Instance.playerInfo.collectedDollsDic = new IntIntDictionary();
            Progress.Instance.playerInfo.collectedDollsDic.Initialize();

            Progress.Instance.Save();
            menuManager.OpenBallOpenMenu();
        }
        else
        {
            tutorialBlocks[currentBlock].SetActive(true);
            currentBlock++;
        }
        
    }
}
