using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Userdata
{
    public List<int> high_score;
    public string user_name = "HaoHao";
    public int id_Skin;
    public UserDataLevel _LevelData;
    public bool isOnFx;
    public bool isOnMusic;
    public List<MissionID> Missions;
    public static Userdata Instance => GameDataManager.Instance.data;
    public void NewUser()
    {
        id_Skin = 0;
        _LevelData = new UserDataLevel();
        _LevelData.NewUser();
        isOnFx = true;
        isOnMusic = true;
        Missions = new List<MissionID>();
    }
}
public class MissionID
{
    int Mission_ID;
    int StepMission;
    int StepCurrent;
}