using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;
using TMPro;

public class PopulateScrollSnap : MonoBehaviour
{
    [SerializeField] DollDatasHolder dollDatasHolder;
    [SerializeField] GameObject dollUiImagePrefab;
    private List<DollDataScriptableObject> dollDatas;
    [SerializeField] SimpleScrollSnap simpleScrollSnap;

    // TODO: Take doll id's from savings
    private void OnEnable()
    {
        int numberOfPanels = simpleScrollSnap.NumberOfPanels;
        for (int i = 0; i < numberOfPanels; i++)
        {
            //simpleScrollSnap.Remove(i);
            simpleScrollSnap.RemoveFromBack();
            Debug.Log("simpleScrollSnap.NumberOfPanels: " + simpleScrollSnap.NumberOfPanels + ", Removing");
        }

        dollDatas = dollDatasHolder.GetDollDatas();

        for (int i = 0; i < Progress.Instance.playerInfo.collectedDollsDic.keys.Count; i++)
        {
            simpleScrollSnap.AddToBack(dollUiImagePrefab);
            GameObject newInstance = simpleScrollSnap.Panels[i].gameObject;
            newInstance.GetComponentInChildren<Image>().sprite = dollDatas[Progress.Instance.playerInfo.collectedDollsDic.keys[i]].dollImage;
            newInstance.GetComponentInChildren<TMP_Text>().text = "У вас " + Progress.Instance.playerInfo.collectedDollsDic.GetValue(Progress.Instance.playerInfo.collectedDollsDic.keys[i]) + " таких кукол!";
            //simpleScrollSnap.Panels[i].GetComponentInChildren<Image>().sprite = dollDatas[Progress.Instance.playerInfo.collectedDollsDic.keys[i]].dollImage;
        }
    }
}
