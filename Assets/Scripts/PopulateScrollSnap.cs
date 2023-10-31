using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;
using TMPro;
using TMPro;

public class PopulateScrollSnap : MonoBehaviour
{
    [SerializeField] DollDatasHolder dollDatasHolder;
    [SerializeField] GameObject dollUiImagePrefab;
    private List<Sprite> dollDatas;
    [SerializeField] SimpleScrollSnap simpleScrollSnap;
    [SerializeField] TMP_Text numberOfDollsText;
    [SerializeField] GameObject bottomBlock;
    [SerializeField] GameObject noDollsBlock;
    [SerializeField] ClickerDollParent dollParent;

    // TODO: Take doll id's from savings
    private void OnEnable()
    {
        int numberOfDolls = Progress.Instance.playerInfo.collectedDollsDic.keys.Count;

        if (numberOfDolls <= 0)
        {
            bottomBlock.SetActive(false);
            noDollsBlock.SetActive(true);
        }
        else
        {
            dollParent.ResetId();
            bottomBlock.SetActive(true);
            noDollsBlock.SetActive(false);

            int numberOfPanels = simpleScrollSnap.NumberOfPanels;
            for (int i = 0; i < numberOfPanels; i++)
            {
                //simpleScrollSnap.Remove(i);
                simpleScrollSnap.RemoveFromBack();
                Debug.Log("simpleScrollSnap.NumberOfPanels: " + simpleScrollSnap.NumberOfPanels + ", Removing");
            }

            dollDatas = null;
            dollDatas = dollDatasHolder.GetDollDatas();

            for (int i = 0; i < numberOfDolls; i++)
            {
                simpleScrollSnap.AddToBack(dollUiImagePrefab);
                GameObject newInstance = simpleScrollSnap.Panels[i].gameObject;
                //newInstance.GetComponentInChildren<Image>().sprite = dollDatas[Progress.Instance.playerInfo.collectedDollsDic.keys[i]];
                //newInstance.GetComponentInChildren<TMP_Text>().text = "Таких кукол у вас: " + Progress.Instance.playerInfo.collectedDollsDic.GetValue(Progress.Instance.playerInfo.collectedDollsDic.keys[i]) + "!";

                newInstance.GetComponentInChildren<Image>().sprite = dollDatas[Progress.Instance.playerInfo.collectedDollsDic.keys[(numberOfDolls - 1) - i]];
                newInstance.GetComponentInChildren<TMP_Text>().text = "Таких кукол у вас: " + Progress.Instance.playerInfo.collectedDollsDic.GetValue(Progress.Instance.playerInfo.collectedDollsDic.keys[(numberOfDolls - 1) - i]) + "!";

            }

            numberOfDollsText.text = "Собрано кукол\n" + Progress.Instance.playerInfo.collectedDollsDic.keys.Count + " из " + dollDatas.Count;
        }
    }
}
