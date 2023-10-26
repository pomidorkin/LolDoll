using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class PopulateScrollSnap : MonoBehaviour
{
    [SerializeField] DollDatasHolder dollDatasHolder;
    [SerializeField] GameObject dollUiImagePrefab;
    private List<DollDataScriptableObject> dollDatas;
    [SerializeField] SimpleScrollSnap simpleScrollSnap;
    public bool wasPopulated = false;

    // TODO: Take doll id's from savings
    private void OnEnable()
    {
        if (!wasPopulated)
        {
            wasPopulated = true;
            dollDatas = dollDatasHolder.GetDollDatas();

            foreach (DollDataScriptableObject item in dollDatas)
            {
                simpleScrollSnap.AddToBack(dollUiImagePrefab);
                dollUiImagePrefab.GetComponentInChildren<Image>().sprite = item.dollImage;
            }
        }
    }
}
