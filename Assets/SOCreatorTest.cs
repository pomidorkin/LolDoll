using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SOCreatorTest : MonoBehaviour
{
    [SerializeField] Sprite[] images;
    private void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            // MyClass is inheritant from ScriptableObject base class
            DollDataScriptableObject example = ScriptableObject.CreateInstance<DollDataScriptableObject>();
            // path has to start at "Assets"
            string path = "Assets/DollData/Doll_" + i.ToString() +".asset";
            AssetDatabase.CreateAsset(example, path);
            example.dollImage = images[i];
            //Selection.activeObject = example;
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
    }

}
