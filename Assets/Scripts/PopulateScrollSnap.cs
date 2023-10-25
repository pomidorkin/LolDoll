using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateScrollSnap : MonoBehaviour
{
    [SerializeField] DollDatasHolder dollDatasHolder;
    [SerializeField] GameObject dollUiImagePrefab;
    [SerializeField] GameObject contentParent;
    private List<DollDataScriptableObject> dollDatas;

    // TODO: Take doll id's from savings
    private void OnEnable()
    {
        dollDatas = dollDatasHolder.GetDollDatas();

        foreach (DollDataScriptableObject item in dollDatas)
        {
            GameObject newDollUiImage = Instantiate(dollUiImagePrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            newDollUiImage.transform.parent = contentParent.transform;
            newDollUiImage.GetComponentInChildren<Image>().sprite = item.dollImage;
        }
    }
}
