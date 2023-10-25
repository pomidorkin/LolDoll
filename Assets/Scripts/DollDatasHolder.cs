using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollDatasHolder : MonoBehaviour
{
    [SerializeField] List<DollDataScriptableObject> dollDatas;

    public List<DollDataScriptableObject> GetDollDatas()
    {
        return dollDatas;
    }
}
