using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.UI;

public class ClickerDollParent : MonoBehaviour
{
    [SerializeField] SimpleScrollSnap simpleScrollSnap;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] MenuManager menuManager;
    private int selectedDollId;
    private void OnEnable()
    {
        simpleScrollSnap.OnPanelCentered.AddListener(SetSelectedDollImage);
    }
    public void SetSelectedDollImage(int i, int ii)
    {
        Debug.Log("Selected panel id: " + simpleScrollSnap.CenteredPanel);
        selectedDollId = simpleScrollSnap.CenteredPanel;
    }

    public void StartClicking()
    {
        spriteRenderer.sprite = simpleScrollSnap.Panels[selectedDollId].gameObject.GetComponentInChildren<Image>().sprite;
        menuManager.OpenClickerDollImage();
    }
}
