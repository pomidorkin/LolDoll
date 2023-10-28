using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int coins = 0;
    public int clickRevenue = 1;
    public int dollBalls = 0;
    public IntIntDictionary collectedDollsDic = new IntIntDictionary();
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
            SetPlayerInfoLocal();
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
        PlayerPrefs.SetString("data", jsonString);
        PlayerPrefs.Save();
    }

    public void SetPlayerInfoLocal()
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(PlayerPrefs.GetString("data"));
        Debug.Log(PlayerPrefs.GetString("data"));
        if (playerInfo == null)
        {
            playerInfo = new PlayerInfo();
            Save();
        }
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
