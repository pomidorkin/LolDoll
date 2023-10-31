using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Utils;

public class PlaySoundOnEnable : MonoBehaviour
{
    [SerializeField] AudioDataProperty clip;

    private void OnEnable()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
