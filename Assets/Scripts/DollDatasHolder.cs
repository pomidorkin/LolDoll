using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollDatasHolder : MonoBehaviour
{
    [SerializeField] List<Sprite> dollDatas;

    public List<Sprite> GetDollDatas()
    {
        return dollDatas;
    }
}
