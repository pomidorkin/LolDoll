using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int coins = 0;
    public int dollBalls = 10;
    public List<int> collectedDollsId;
    public int record;
    public bool firstStart = false;
}
public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;

    /*[DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();*/

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(playerInfo);
        //SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        if (value != null)
        {
            playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        }
        else
        {
            playerInfo = new PlayerInfo();
            Save();
        }
    }
}
