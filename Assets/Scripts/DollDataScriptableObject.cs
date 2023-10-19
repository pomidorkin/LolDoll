using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DollData", menuName = "ScriptableObjects/DollDataScriptableObject", order = 1)]
public class DollDataScriptableObject : ScriptableObject
{
    [SerializeField] public string dollName;
    [SerializeField] public int rarity = 1;
    [SerializeField] public Sprite dollImage;
}
