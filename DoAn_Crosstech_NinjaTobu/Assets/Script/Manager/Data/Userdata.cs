using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Userdata
{
    public List<int> high_score;
    public string user_name;
    public int id_Skin;
    public UserDataLevel _LevelData;
    public static Userdata Instance => GameDataManager.Instance.data;
    public void NewUser()
    {
        _LevelData = new UserDataLevel();
        _LevelData.NewUser();
    }
}
