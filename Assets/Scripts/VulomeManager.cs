using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VulomeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject soundManagerPopup;
    [SerializeField] GameObject loudIcon;
    [SerializeField] GameObject muteIcon;
    private bool popUpClosed = true;
    private bool muteIconActivated = false;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChangedHandler(); });
    }
    public void OpenSoundManagerPopUp()
    {
        soundManagerPopup.SetActive(popUpClosed);
        popUpClosed = !popUpClosed;
        volumeSlider.value = AudioListener.volume;
    }

    public void CloseVolumePopup()
    {
        soundManagerPopup.SetActive(false);
        popUpClosed = true;
    }

    private void OnVolumeChangedHandler()
    {
        float val = volumeSlider.value;
        SoundManager.Instance.ChangeMasterVolume(val);
        if (muteIconActivated && (val > 0))
        {
            loudIcon.SetActive(true);
            muteIcon.SetActive(false);
            muteIconActivated = false;
        }
        else if (!muteIconActivated && (val <= 0))
        {
            loudIcon.SetActive(false);
            muteIcon.SetActive(true);
            muteIconActivated = true;
        }
    }
}
