using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    private void OnEnable()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
