using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.UI;
using Plugins.Audio.Utils;

public class ClickerDollParent : MonoBehaviour
{
    [SerializeField] SimpleScrollSnap simpleScrollSnap;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] MenuManager menuManager;
    [SerializeField] AudioDataProperty clip;
    private int selectedDollId;
    private void OnEnable()
    {
        simpleScrollSnap.OnPanelCentered.AddListener(SetSelectedDollImage);
    }
    public void SetSelectedDollImage(int i, int ii)
    {
        Debug.Log("Selected panel id: " + simpleScrollSnap.CenteredPanel);
        selectedDollId = simpleScrollSnap.CenteredPanel;
        SoundManager.Instance.PlaySound(clip);
    }

    public void StartClicking()
    {
        spriteRenderer.sprite = simpleScrollSnap.Panels[selectedDollId].gameObject.GetComponentInChildren<Image>().sprite;
        float ratio = 500f / spriteRenderer.sprite.texture.height; 
        spriteRenderer.gameObject.transform.localScale = new Vector2(1f * ratio, 1f * ratio);
        menuManager.OpenClickerDollImage();
    }

    public void ResetId()
    {
        selectedDollId = 0;
    }
}
